pipeline {
    agent any
    
    environment {
        DOTNET_CLI_HOME = "/tmp/dotnet"
        DOTNET_ROOT = "C:\\Program Files\\dotnet"
    }
    
    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out code from GitHub...'
                checkout scm
            }
        }
        
        stage('Restore') {
            steps {
                echo 'Restoring NuGet packages...'
                bat 'dotnet restore ProductsAPIForTechGig.csproj'
            }
        }
        
        stage('Build') {
            steps {
                echo 'Building the application...'
                bat 'dotnet build ProductsAPIForTechGig.csproj --configuration Release --no-restore'
            }
        }
    }
    
    post {
        success {
            echo 'Pipeline completed successfully!'
        }
        failure {
            echo 'Pipeline failed!'
        }
    }
}
