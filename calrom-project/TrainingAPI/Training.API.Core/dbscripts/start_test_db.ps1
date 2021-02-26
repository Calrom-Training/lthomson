docker-compose -f .\docker-compose.yml up -d --remove-orphans

docker exec training_mongo sh -c "exec mongoimport --db=TestTrainingApiDb --collection=Users --file=./docker-entrypoint-initdb.d/Users.json"
docker exec training_mongo sh -c "exec mongoimport --db=TestTrainingApiDb --collection=Messages --file=./docker-entrypoint-initdb.d/Messages.json"