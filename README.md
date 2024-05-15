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
* motorcycle rental api is running in address `localhost:3000/swagger/index.html` 
* if the api does not work just restart your container.

## Rabbit
* Connection: `motorcycle-producer`
* Exchange: `motorcycle`
* Routing key: `motorcycle-created-event`

## Application Developed
The objective is to create an application for managing motorcycle rentals and delivery personnel. When a delivery person is registered and has an active rental, they can also make deliveries of available orders on the platform.

### Use Cases
- As an admin user, I want to register a new motorcycle.
  - The required motorcycle data are Identifier, Year, Model, and License Plate.
  - The license plate is unique and cannot be duplicated.
  - When the motorcycle is registered, the application should generate a motorcycle registered event.
    - The notification should be published via messaging.
    - Create a consumer to notify when the motorcycle year is "2024".
    - Once the message is received, it should be stored in the database for future reference.
- As an admin user, I want to query the existing motorcycles on the platform and be able to filter by license plate.
- As an admin user, I want to modify a motorcycle by changing only its license plate that was incorrectly registered.
- As an admin user, I want to remove a motorcycle that was incorrectly registered, provided it has no rental records.
- As a delivery person user, I want to register on the platform to rent motorcycles.
  - The delivery person data are (identifier, name, tax ID, date of birth, driver's license number, driver's license type, driver's license image).
  - Valid driver's license types are A, B, or both A+B.
  - The tax ID is unique and cannot be duplicated.
  - The driver's license number is unique and cannot be duplicated.
- As a delivery person, I want to upload a photo of my driver's license to update my registration.
  - The file format must be png or bmp.
  - The photo cannot be stored in the database; you can use a storage service (local disk, Amazon S3, MinIO, or others).
- As a delivery person, I want to rent a motorcycle for a period.
  - The available rental plans are:
    - 7 days at a cost of R$30.00 per day
    - 15 days at a cost of R$28.00 per day
    - 30 days at a cost of R$22.00 per day
    - 45 days at a cost of R$20.00 per day
    - 50 days at a cost of R$18.00 per day
  - The rental must have a start date, an end date, and a predicted end date.
  - The rental start date is the first day after the creation date.
  - Only delivery personnel qualified in category A can rent a motorcycle.
- As a delivery person, I want to inform the date I will return the motorcycle and check the total rental cost.
  - When the return date is earlier than the predicted end date, the daily rates and an additional fine will be charged.
    - For the 7-day plan, the fine is 20% of the unfulfilled daily rates.
    - For the 15-day plan, the fine is 40% of the unfulfilled daily rates.
  - When the return date is later than the predicted end date, an additional R$50.00 will be charged for each additional day.
