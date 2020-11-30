pipeline {
    environment {
        testingregistry = "knoxie2/front_end_app_testing"
        productionregistry = "knoxie2/front_end_app"
        registryCredential = 'knoxie2'
        dockerImage = ''
        HOME = '/tmp'

    } 
    agent any
    stages {
        stage('Building image for Testting') {
          when {
              branch 'development'
            }
            steps {
              script {
                dockerImage = docker.build testingregistry + ":latest"
              }
            }
        }
        
        stage('Building image for Production') {
          when {
              branch 'staging'
            }
            steps {
              script {
                dockerImage = docker.build productionregistry + ":latest"
              }
            }
        }
        
        stage('Running Unit Tests') {
          when {
              branch 'development'
            }
            steps {
              script {
                docker.image("knoxie2/front_end_app_testing:latest").inside("""--entrypoint=''""") {
                  sh 'dotnet --version'
                  sh 'cd src/FrontEndApp.Unittests'
                  sh 'dotnet test --logger "trx;LogFileName=unit_tests.xml"'
                }
              }
            }
        }

        stage('Push Image to Ducker Hub') {
           when {
              not {
                branch 'main'
              }
            }
            steps{    
              script {
                docker.withRegistry( '', registryCredential ) {
                  dockerImage.push()
                }
              }
            }
        }

        stage('Remove Unused Testing docker image') {
           when {
              branch 'development'
            }
            steps{
              sh "docker rmi $testingregistry:latest" 
            }
        }

        stage('Remove Unused Production docker image') {
           when {
              branch 'staging'
            }
            steps{
              sh "docker rmi $productionregistry:latest"
            }
        }

        stage('Deploy to Staging environment') {
          when {
              branch 'staging'
            }
            steps{
              sh "ansible -m ping all"
              sh "ansible-playbook ansible-playbooks/pull_webshop_front_end_testing.yml -i "${HOSTS}""
              //ansiblePlaybook(credentialsId: 'Ansible', playbook: 'pull_webshop_front_end_testing.yml',inventory: "${HOSTS}")
            }
        }
         stage('Deploy to Production environment') {
          when {
              branch 'main'
            }
            steps{
              sh "ansible -m ping all"
            }
        }
    }
}
