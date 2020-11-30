pipeline {
    environment {
        registry = "knoxie2/front_end_app"
        registryCredential = 'knoxie2'
        dockerImage = ''
        HOME = '/tmp'
    } 
    agent any
    stages {
        stage('Building image') {
            steps {
              script {
                dockerImage = docker.build registry + ":$BUILD_NUMBER"
              }
            }
        }

        stage('Running Unit Tests') {
          when {
              branch 'development'
            }
            steps {
              script {
                docker.image('knoxie2/front_end_app' + ":$BUILD_NUMBER").inside("""--entrypoint=''""") {
                  sh 'dotnet --version'
                  sh 'cd src/FrontEndApp.Unittests'
                  sh 'dotnet test --logger "trx;LogFileName=unit_tests.xml"'
                }
              }
            }
        }

        stage('Push Image to Ducker Hub') {
            when {
              branch 'development'
            }
            steps{    
              script {
                docker.withRegistry( '', registryCredential ) {
                  dockerImage.push()
                }
              }
            }
        }

        stage('Remove Unused docker image') {
           when {
              branch 'development'
            }
            steps{
              sh "docker rmi $registry:$BUILD_NUMBER"
            }
        }

        stage('Deploy to Staging environment') {
          when {
              branch 'development'
            }
            steps{
              sh "ansible -m ping all"
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
    // post {
    //     always {
    //         step([$class: 'MSTestPublisher', testResultsFile:"**/unit_tests.xml", failOnError: true, keepLongStdio: true])
    //     }
    // }
}
