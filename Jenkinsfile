pipeline {
    environment {
        HOME = '/tmp'
    } 
    agent { 
        dockerfile {
            filename 'Dockerfile'
            reuseNode true
            args '--entrypoint=\'\''
        }
    }
    stages {
        stage('Test') {
            steps {
                sh 'dotnet --version'
                sh 'cd src/FrontEndApp.Unittests'
                sh 'dotnet test --logger "trx;LogFileName=unit_tests.xml"'
                sh 'cd ..'
                sh 'cd ..'
            }
        }
    }
    // post {
    //     always {
    //         step([$class: 'MSTestPublisher', testResultsFile:"**/unit_tests.xml", failOnError: true, keepLongStdio: true])
    //     }
    // }
}