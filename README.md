# Starkit.TechnicalTest.Names.API

Justificacion de decisiones:
	- Para el proyecto fue utilizado .NET 6.0
	- Por parte del Testing se decidio utilizar xUnit 2.4.2
	- Debido a que el proyecto hace uso del archivo json provisto a modo de base de datos considere optimo generar una carpeta interna llamada Data tanto en el proyecto de Testing como en el app para asegurar la correcta obtencion de los datos
	- Se decidio generar como modelo una clase response debido a que para unicamente hacer uso de la clase Person hubiese sido necesario realizar ediciones sobre el archivo json provisto, dado que el mismo se considero inhalterable para la naturaleza de la prueba se evaluo como una solucion viable

Para la ejecucion del software se hace uso de Swagger donde se hace uso del metodo GET con sus filtros indicados en la tarea indicada.