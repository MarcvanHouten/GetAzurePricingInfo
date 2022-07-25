#!/bin/bash

# Variable block
let randomIdentifier=$RANDOM*$RANDOM
location="northeurope"
resourceGroup="AzurePricingApp"
server="sql-server-$randomIdentifier"
database="azurepricingdb$randomIdentifier"
login="azureuser"
password="Pa$$w0rD-$randomIdentifier"
# Specify appropriate IP address values for your environment
# to limit access to the SQL Database server
startIp="94.211.65.87"
endIp="94.211.65.87"

echo "Using resource group $resourceGroup with login: $login, password: $password..."

# Create Resource Group 
echo "Creating $resourceGroup in $location..."
az group create --name $resourceGroup --location "$location"

#Create SQL Server
echo "Creating $server in $location..."
az sql server create --name $server --resource-group $resourceGroup --location "$location" --admin-user $login --admin-password $password

#Create Firewall Rule
echo "Configuring firewall..."
az sql server firewall-rule create --resource-group $resourceGroup --server $server -n AllowYourIp --start-ip-address $startIp --end-ip-address $endIp

#Create database

echo "Creating $database in serverless tier"
az sql db create \
    --resource-group $resourceGroup \
    --server $server \
    --name $database \
    --edition GeneralPurpose \
    --compute-model Serverless \
    --family Gen5 \
    --capacity 2

login: azureuser, password: Pa9w0rD-26867153