#!/bin/bash

# Build script for kittyn.cat Shared Utilities
# Creates VCC-compatible package for shared utilities

set -e

# Colors
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m'

# Configuration
PACKAGE_NAME="cat.kittyn.shared-utilities"
ROOT_DIR="cat.kittyn.shared-utilities"

# Get the directory where this script is located
SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
cd "$SCRIPT_DIR"

# Function to print colored output
print_info() {
    echo -e "${BLUE}[INFO]${NC} $1"
}

print_success() {
    echo -e "${GREEN}[SUCCESS]${NC} $1"
}

print_error() {
    echo -e "${RED}[ERROR]${NC} $1"
}

# Parse version argument
if [ -z "$1" ]; then
    print_error "Version argument required: major, minor, patch, or specific version (e.g., 1.2.3)"
    echo "Usage: $0 <major|minor|patch|x.y.z>"
    exit 1
fi

VERSION_ARG=$1

# Read current version from package.json
CURRENT_VERSION=$(cat "kittyncat_tools/$ROOT_DIR/package.json" | grep '"version"' | sed -E 's/.*"version": "([^"]+)".*/\1/')
print_info "Current version: $CURRENT_VERSION"

# Parse current version
IFS='.' read -r -a VERSION_PARTS <<< "$CURRENT_VERSION"
MAJOR="${VERSION_PARTS[0]}"
MINOR="${VERSION_PARTS[1]}"
PATCH="${VERSION_PARTS[2]}"

# Determine new version
case "$VERSION_ARG" in
    major)
        NEW_VERSION="$((MAJOR + 1)).0.0"
        ;;
    minor)
        NEW_VERSION="$MAJOR.$((MINOR + 1)).0"
        ;;
    patch)
        NEW_VERSION="$MAJOR.$MINOR.$((PATCH + 1))"
        ;;
    *)
        # Validate version format
        if [[ ! "$VERSION_ARG" =~ ^[0-9]+\.[0-9]+\.[0-9]+$ ]]; then
            print_error "Invalid version format. Use major, minor, patch, or x.y.z"
            exit 1
        fi
        NEW_VERSION="$VERSION_ARG"
        ;;
esac

print_info "New version: $NEW_VERSION"

# Update package.json version
print_info "Updating package.json..."
if [[ "$OSTYPE" == "darwin"* ]]; then
    # macOS
    sed -i '' "s/\"version\": \"$CURRENT_VERSION\"/\"version\": \"$NEW_VERSION\"/" "kittyncat_tools/$ROOT_DIR/package.json"
else
    # Linux
    sed -i "s/\"version\": \"$CURRENT_VERSION\"/\"version\": \"$NEW_VERSION\"/" "kittyncat_tools/$ROOT_DIR/package.json"
fi

# Update download URL in package.json
DOWNLOAD_URL="https://github.com/kittynXR/immersive-scaler/releases/download/shared-utilities-v$NEW_VERSION/$PACKAGE_NAME-$NEW_VERSION.zip"
if [[ "$OSTYPE" == "darwin"* ]]; then
    sed -i '' "s|\"url\": \"[^\"]*\"|\"url\": \"$DOWNLOAD_URL\"|" "kittyncat_tools/$ROOT_DIR/package.json"
else
    sed -i "s|\"url\": \"[^\"]*\"|\"url\": \"$DOWNLOAD_URL\"|" "kittyncat_tools/$ROOT_DIR/package.json"
fi

# Create output directory for VPM-compatible package
OUTPUT_DIR="output-shared-utilities"
rm -rf "$OUTPUT_DIR"
mkdir -p "$OUTPUT_DIR"

# Copy package files directly (VPM expects package.json at root)
print_info "Copying package files..."
cp -r "kittyncat_tools/$ROOT_DIR"/* "$OUTPUT_DIR/"

# Create versioned zip
ZIP_FILE="$PACKAGE_NAME-$NEW_VERSION.zip"
print_info "Creating $ZIP_FILE..."
cd "$OUTPUT_DIR"
zip -r "../$ZIP_FILE" *
cd ..

# Clean up
rm -rf "$OUTPUT_DIR"

print_success "Shared utilities package $NEW_VERSION created successfully!"
print_info "Package file: $ZIP_FILE"
print_info ""
print_info "Next steps:"
print_info "1. Test the package in a Unity project"
print_info "2. Upload $ZIP_FILE to GitHub releases when ready"
print_info "3. Update other packages to use version $NEW_VERSION as dependency"