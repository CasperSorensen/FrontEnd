#!/usr/bin/env sh

set -x
ansible-playbook pull_webshop_front_end_testing.yml -i /etc/ansible/hosts --private-key ${ansible_key} -u root
set +x
