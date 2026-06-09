pipeline {
    agent any

    environment {
        DOCKER_IMAGE = 'todo-backend'
        DOCKER_TAG = "v${env.BUILD_ID}"
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build Docker Image') {
            steps {
                script {
                    echo "Building Docker image ${DOCKER_IMAGE}:${DOCKER_TAG}..."
                    // Using 'bat' for Windows environment compatibility as per your frontend configuration
                    bat "docker build -t ${DOCKER_IMAGE}:${DOCKER_TAG} -t ${DOCKER_IMAGE}:latest ."
                }
            }
        }

        stage('Test') {
            steps {
                echo "Running backend tests..."
                // Placeholder for running .NET tests
                // bat "dotnet test"
            }
        }

        stage('Deploy / Run') {
            steps {
                script {
                    echo "Running the backend container locally..."
                    // Stop and remove existing container if it exists safely on Windows
                    bat "docker rm -f todo-backend-container 2>nul || echo Container did not exist."
                    // Bind the container port 5240 to the host port 5240 so the frontend can reach it
                    bat "docker run -d -p 5240:5240 --name todo-backend-container ${DOCKER_IMAGE}:${DOCKER_TAG}"
                }
            }
        }
    }

    post {
        always {
            // Safely clean up the local Windows workspace directory
            cleanWs()
        }
        success {
            echo 'Pipeline completed successfully!'
        }
        failure {
            echo 'Pipeline failed. Please check the logs.'
        }
    }
}
