pipeline {
    environment {

        testingregistry = "knoxie2/front_end_app_testing"
        productionregistry = "knoxie2/front_end_app"

        registry = "knoxie2/front_end_app"

        registryCredential = 'knoxie2'
        dockerImage = ''
        HOME = '/tmp'
    } 
    agent any
    stages {

        stage('Building image for Testting') {

        stage('Building image') {
            steps {
              script {
                dockerImage = docker.build registry + ":$BUILD_NUMBER"
              }
            }

        }

        stage('Test') {

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
                docker.image('knoxie2/front_end_app' + ":$BUILD_NUMBER").inside("""--entrypoint=''""") {
                  sh 'dotnet --version'
                  sh 'cd src/FrontEndApp.Unittests'
                  sh 'dotnet test --logger "trx;LogFileName=unit_tests.xml"'
                }
              }
            }
        }

        stage('Push Image to Ducker Hub') {
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
              sh "docker rmi knoxie2/front_end_app_testing:latest" 
            }
        }

        stage('Remove Unused Production docker image') {
           when {
              branch 'staging'
            }
            steps{
              sh "docker rmi knoxie2/front_end_app:latest"
            }
        }

        stage('Deploy to Staging environment') {
          when {
              branch 'staging'
            }
            steps{
              sh "ansible-playbook pull_webshop_front_end_testing.yml -l production"
            }
        }
         stage('Deploy to Production environment') {

        stage('Remove Unused docker image') {
            steps{
              sh "docker rmi $registry:$BUILD_NUMBER"
            }
        }

        stage('Ansible test') {

          when {
              branch 'main'
            }
            steps{
              sh "ansible -m ping all"
            }
        }
        
    }
    // post {
    //     always {
    //         step([$class: 'MSTestPublisher', testResultsFile:"**/unit_tests.xml", failOnError: true, keepLongStdio: true])
    //     }
    // }

}
