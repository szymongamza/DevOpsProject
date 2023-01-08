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
                sh 'docker build --target build -f ./ToDoListAPI/Dockerfile  -t image_build .'
                sh 'docker run --rm -v ${PWD}:/app image_build'
            }
        }
        stage('Test') {
            steps {
                sh 'docker build --target test -f ./ToDoListAPI/Dockerfile -t image_test .'
                sh 'docker run --rm -v ${PWD}:/app image_test'
            }
        }
        stage('Publish') {
            steps {
                sh 'docker build --target publish -f ./ToDoListAPI/Dockerfile -t image_publish .'
                sh 'docker run --rm -v ${PWD}:/app image_publish'
            }
        }
        stage('Deploy') {
            steps {
                sh 'docker build --target final -f ./ToDoListAPI/Dockerfile -t image_run .'
                sh 'docker run -it -d image_run'
            }
        }

    }
}
