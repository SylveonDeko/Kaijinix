#!/bin/sh

SCRIPT_DIR=$(dirname "$(realpath "$0")")

if [ -f "$SCRIPT_DIR/Kaijinix.Headless.SDL2" ]; then
    Kaijinix_BIN="Kaijinix.Headless.SDL2"
fi

if [ -f "$SCRIPT_DIR/Kaijinix" ]; then
    Kaijinix_BIN="Kaijinix"
fi

if [ -z "$Kaijinix_BIN" ]; then
    exit 1
fi

COMMAND="env DOTNET_EnableAlternateStackCheck=1"

if command -v gamemoderun > /dev/null 2>&1; then
    COMMAND="$COMMAND gamemoderun"
fi

exec $COMMAND "$SCRIPT_DIR/$Kaijinix_BIN" "$@"
