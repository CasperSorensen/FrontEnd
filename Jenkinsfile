pipeline {
    environment {
        registry = "knoxie2/front_end_app"
        registryCredential = 'knoxie2'
        dockerImage = '' 
    } 
    agent any
    stages {
        stage('Test') {
            steps {
                sh 'dotnet --version'
                sh 'cd src/FrontEndApp.Unittests'
                sh 'dotnet test --logger "trx;LogFileName=unit_tests.xml"'
            }
        }
        stage('Building image') {
            steps {
              script {
                dockerImage = docker.build registry + ":$BUILD_NUMBER"
              }
            }
        }
        stage('Deploy Image') {
            steps{    
              script {
                docker.withRegistry( '', registryCredential ) {
                  dockerImage.push()
                }
              }
            }
        }
        stage('Remove Unused docker image') {
            steps{
              sh "docker rmi $registry:$BUILD_NUMBER"
            }
        }
    }
    // post {
    //     always {
    //         step([$class: 'MSTestPublisher', testResultsFile:"**/unit_tests.xml", failOnError: true, keepLongStdio: true])
    //     }
    // }
}
