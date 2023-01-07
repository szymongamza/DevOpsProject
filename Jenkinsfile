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
                sh 'docker build -f ./ToDoListAPI/.docker/Dockerfile.b -t image_build .'
                sh 'docker run --rm -v ${PWD}:/app image_build'
            }
        }
        stage('Test') {
            steps {
                sh 'docker build -f ./ToDoListAPI/.docker/Dockerfile.t -t image_test .'
                sh 'docker run --rm -v ${PWD}:/app image_test'
            }
        }
        stage('Publish') {
            steps {
                sh 'docker build -f ./ToDoListAPI/.docker/Dockerfile.pub -t image_publish .'
                sh 'docker run --rm -v ${PWD}:/app image_publish'
            }
        }
        stage('Deploy') {
            steps {
                sh 'docker build -f ./ToDoListAPI/.docker/Dockerfile.dep -t image_run .'
                sh 'docker run -it -d image_run'
            }
        }

    }
}