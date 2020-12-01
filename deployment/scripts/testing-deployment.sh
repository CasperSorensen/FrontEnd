#!/usr/bin/env sh

set -x
ansible -m ping production
set +x