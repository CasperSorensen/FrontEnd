#!/usr/bin/env sh

set -x
ansible-playbook pull_webshop_front_end_testing.yml -i /etc/ansible/hosts --private-key /var/lib/jenkins/.ssh/id_rsa -u root
set +x
