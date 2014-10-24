RabbitMQTest
============

1. Descargar e instalar Erlang desde [http://www.erlang.org/](http://www.erlang.org/)
2. Descarg e instalar RabbitMQ desde [http://www.rabbitmq.com/](http://www.rabbitmq.com/)
3. (opcional) El archivo de configuración se encuentra en: "C:\Users\%USERNAME%\AppData\Roaming\RabbitMQ". Crear archivo sin la extensión example.
4. Levantar servidor en consola con permisos de administrador con: "C:\Program Files (x86)\RabbitMQ Server\rabbitmq_server-3.4.0\sbin\rabbitmq-service.bat" start|stop
5. Abrir el puerto del firewall: 5672
6. Para habilitar sitio de administración, ejecutar sbin\rabbitmq-plugins enable rabbitmq_management
7. Acceder a la administración del servidor con guest:guest en la url [http://localhost:15672](http://localhost:15672)
8. Crear un usuario sin tag, seleccionar el usuario y presionar "set permission"