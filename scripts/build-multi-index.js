#!/usr/bin/env node

const fs = require('fs');
const path = require('path');

// Get command line arguments
const args = process.argv.slice(2);
if (args.length < 2) {
    console.error('Usage: build-multi-index.js <output-path> <source.json-path>');
    process.exit(1);
}

const outputPath = args[0];
const sourcePath = args[1];

// Read source.json
const sourceData = JSON.parse(fs.readFileSync(sourcePath, 'utf8'));

// Directory containing all packages
const packagesDir = 'kittyncat_tools';

// Find all packages in the directory
const packageDirs = fs.readdirSync(packagesDir)
    .filter(dir => {
        const packageJsonPath = path.join(packagesDir, dir, 'package.json');
        return fs.existsSync(packageJsonPath);
    });

console.log(`Found ${packageDirs.length} packages:`, packageDirs);

// Initialize packages object
const packages = {};

// Process each package
packageDirs.forEach(packageDir => {
    const packageJsonPath = path.join(packagesDir, packageDir, 'package.json');
    const packageData = JSON.parse(fs.readFileSync(packageJsonPath, 'utf8'));
    
    // Create VPM package entry
    const vpmPackage = {
        "name": packageData.name,
        "displayName": packageData.displayName,
        "version": packageData.version,
        "unity": packageData.unity,
        "unityRelease": packageData.unityRelease,
        "description": packageData.description,
        "author": packageData.author,
        "license": packageData.license,
        "licensesUrl": packageData.licensesUrl,
        "changelogUrl": packageData.changelogUrl,
        "documentationUrl": packageData.documentationUrl,
        "dependencies": packageData.dependencies || {},
        "vpmDependencies": packageData.vpmDependencies || {},
        "keywords": packageData.keywords || [],
        "url": packageData.url,
        "samples": packageData.samples || []
    };
    
    // Initialize package entry if not exists
    if (!packages[packageData.name]) {
        packages[packageData.name] = {
            versions: {}
        };
    }
    
    // Add version
    packages[packageData.name].versions[packageData.version] = vpmPackage;
    
    console.log(`Added ${packageData.name} v${packageData.version}`);
});

// Load existing index.json if it exists to preserve old versions
let existingPackages = {};
if (fs.existsSync(outputPath)) {
    try {
        const existingData = JSON.parse(fs.readFileSync(outputPath, 'utf8'));
        existingPackages = existingData.packages || {};
        console.log('Loaded existing index.json');
    } catch (error) {
        console.warn('Warning: Could not parse existing index.json, creating new one');
    }
}

// Merge existing versions with new ones
Object.keys(packages).forEach(packageName => {
    if (existingPackages[packageName]) {
        // Merge versions, new ones override old ones with same version number
        packages[packageName].versions = {
            ...existingPackages[packageName].versions,
            ...packages[packageName].versions
        };
    }
});

// Add any packages from existing that aren't in the new build
Object.keys(existingPackages).forEach(packageName => {
    if (!packages[packageName]) {
        packages[packageName] = existingPackages[packageName];
        console.log(`Preserved package ${packageName} from existing index.json`);
    }
});

// Create final index.json structure
const indexData = {
    "name": sourceData.name,
    "author": sourceData.author,
    "url": sourceData.url,
    "id": sourceData.id,
    "description": sourceData.description,
    "packages": packages
};

// Write index.json
fs.mkdirSync(path.dirname(outputPath), { recursive: true });
fs.writeFileSync(outputPath, JSON.stringify(indexData, null, 2));

console.log('\nSuccessfully built index.json:');
Object.keys(packages).forEach(packageName => {
    const versions = Object.keys(packages[packageName].versions);
    console.log(`- ${packageName}: ${versions.length} version(s), latest: ${versions[versions.length - 1]}`);
});