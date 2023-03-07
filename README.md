# Rabbitmq-Producer
Exemplo de uso do RabbitMQ como Producer.

Utilizado TempData para armazenar os dados enviados.

# Testes

execute o comando do docker CLI para gerar o container do RabbitMQ

-> docker run -d --hostname rabbitmq --name rabbitmq -p 15672:15672 -p 5672:5672  rabbitmq:management  
.      
.      
O usuario e senha de acesso localhost é  guest
