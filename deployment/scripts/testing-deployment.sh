#!bin/bash

set -x
ansible -m ping production
set +x