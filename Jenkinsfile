pipeline {
    environment {
        testingregistry = "knoxie2/front_end_app_testing"
        productionregistry = "knoxie2/front_end_app"
        registryCredential = 'knoxie2'
        version = "latest"
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
                dockerImage = docker.build testingregistry + ":$BUILD_NUMBER"
              }
            }
        }
<<<<<<< HEAD
        
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
        
=======

>>>>>>> development
        stage('Running Unit Tests') {
          when {
              branch 'development'
            }
            steps {
              script {
                docker.image('knoxie2/front_end_app_testing' + ":latest").inside("""--entrypoint=''""") {
                  sh 'dotnet --version'
                  sh 'cd src/FrontEndApp.Unittests'
                  sh 'dotnet test --logger "trx;LogFileName=unit_tests.xml"'
                }
              }
            }
        }

        stage('Push Image to Ducker Hub') {
<<<<<<< HEAD
           when {
              not {
                branch 'main'
              }
=======
            when {
              branch 'development'
>>>>>>> development
            }
            steps{    
              script {
                docker.withRegistry( '', registryCredential ) {
                  dockerImage.push()
                }
              }
            }
        }

<<<<<<< HEAD
        stage('Remove Unused testing docker image') {
           when {
              branch 'development'
            }
            steps{
              sh "docker rmi $testingregistry:$version" 
            }
        }

        stage('Remove Unused production docker image') {
           when {
              branch 'staging'
            }
=======
        stage('Remove Unused docker image') {
           when {
              branch 'development'
            }
>>>>>>> development
            steps{
              sh "docker rmi $productionregistry:$version"
            }
        }

        stage('Deploy to Staging environment') {
          when {
<<<<<<< HEAD
              branch 'staging'
=======
              branch 'development'
>>>>>>> development
            }
            steps{
              sh "ansible -m ping all"
            }
        }
<<<<<<< HEAD

=======
>>>>>>> development
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
