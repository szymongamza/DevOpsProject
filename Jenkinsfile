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
                    docker run --name temp_cont image_deploy
                    docker exec temp_cont ls
                    docker cp temp_cont:/app /app
                    docker rm -f temp_cont
                """
                sh """
                    docker build -f Dockerfile.pub -t image_publish
                    docker run -d --name publish -tty image_publish
                """
            }
        }

    }
}
