#!/bin/bash

# Variable for resource group name
resourceGroupName="AzurePricingApp"
location="northeurope"

# Variable for account name with a randomnly generated suffix
let suffix=$RANDOM*$RANDOM
accountName="cosmosaccount-$suffix"

az group create \
    --name $resourceGroupName \
    --location $location

az cosmosdb create \
    --resource-group $resourceGroupName \   
    --name $accountName \
    --locations regionName=$location
    --capabilities EnableTable


