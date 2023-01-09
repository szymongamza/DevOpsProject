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
        stage('Publish') {
            steps {
                sh """
                    docker build -f Dockerfile.pub -t image_deploy .
                    docker run -d --name temp_cont --tty image_deploy
                    docker cp temp_cont:/app/publish/ ./artifacts
                    docker rm -f temp_cont
                    zip zipFile: 'win-x64.zip', archive: false, dir: 'artifacts/win-x64'
                    tar file: 'linux-x64.tar', archive: false, dir: 'artifacts/linux-x64'
                    tar file: 'osx-x64.tar', archive: false, dir: 'artifacts/osx-x64'
                    archiveArtifacts artifacts: 'win-x64.zip', fingerprint: true
                    archiveArtifacts artifacts: 'linux-x64.tar', fingerprint: true
                    archiveArtifacts artifacts: 'osx-x64.tar', fingerprint: true
                """
            }
        }
    }
}
