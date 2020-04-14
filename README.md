# Prueba de Árbol Binario (Binary Tree)
---

### La prueba del árbol binario propuesta consiste en lo siguiente:

Debe estar dividido en:
  - Controladores
  - Servicios
  - Repositorios
  - Entidades (Arbol y Nodo)

Los controladores solo deben llamar a los servicios y recoger los distintos tipos de errores, devolviendo una respuesta adecuada en cada caso, nada de lógica.

Los servicios deben manejar la lógica de negocio, ejecutar las operaciones correspondientes sobre el modelo con los datos de entrada del controlador y  llamar a los repositorios para persistencia de las entidades.

Un árbol debe estar identificado con un UUID y debe ser guardado en Redis (llave=UUID, valor=lista de enteros).

---

### La aplicación debe tener dos endpoints:
  - 1: crear árboles por petición POST con un json que conttenga una lista de enteros, el arbol debe respetar el orden de estos datos como orden de entrada al árbol, este endpoint devuelve solo el UUID.
  - 2: endpoint de consulta por GET del mínimo ancestro común de un árbol dado un UUID de árbol y un par de enteros, si no tiene mínimo ancestro en común devolver una excepción.