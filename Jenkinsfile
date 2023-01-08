pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                git url:'https://github.com/szymongamza/DevOpsJenkinsTry.git', branch: 'main'
            }
        }
        stage('Build') {
            steps {
                sh 'docker build -f Dockerfile.b  -t image_build .'
            }
        }
        stage('Test') {
            steps {
                sh 'docker build -f Dockerfile.t -t image_test .'
            }
        }
        stage('Deploy') {
            steps {
                sh """
                    docker build -f Dockerfile.dep -t image_deploy .
                    docker run -d --name temp_cont --tty image_deploy
                    docker cp temp_cont:/app /tmp
                    docker rm -f temp_cont
                """
                sh """
                    docker build -f Dockerfile.pub -t image_publish .
                    rm /tmp/app
                """
            }
        }

    }
}
