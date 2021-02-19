docker-compose -f .\docker-compose.yml up -d --remove-orphans
docker exec -i training_mongo sh -c 'mongoimport -c Users -d TestTrainingApiDb' < ./TestUserDb/Users.json
docker exec -i training_mongo sh -c 'mongoimport -c Messages -d TestTrainingApiDb' < ./TestUserDb/Messages.json