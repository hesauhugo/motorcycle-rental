# Motorcycle Rental

## Monolithic Architecture
<div align="center">
    <img src = "./images/monolithic-architecture.svg">
</div>

## Docker
* Inside docker compose file execute the following:
```console
    docker compose --project-name motorcycle-rental up -d
```
* postgresql is running in port `5433`
* rabbitmq is running int address:  `localhost:15672`, user: `guest`, psw: `guest`
* motorcycle rental api is running in address `` 

## Rabbit
* Connection: `motorcycle-producer`
* Exchange: `motorcycle`
* Routing key: `motorcycle-created-event`