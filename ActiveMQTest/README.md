ActiveMQTest
============

1. Ir a la url: [http://activemq.apache.org/download.html](http://activemq.apache.org/download.html) y elegir el �ltimo release. En la siguiente pantalla descargar la aplicaci�n.
2. Descomprimir el zip
3. Modificar archivo conf\adminq y cambiar managementContext > createConnector a true
4. Abrir un cmd y ejecutar "c:\Users\zeke\Desktop\apache-activemq-5.10.0\bin\win64\activemq"
5. Acceder a la administraci�n del servidor con admin:admin en la url [http://localhost:8161/admin](http://localhost:8161/admin)
6. En el sitio crear la cola con el mismo nombre del ejemplo
7. Abrir el puerto del firewall: 61616