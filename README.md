# BuscaComic
Para que la aplicación tenga un correcto acceso al API de Marvel es necesario
rellenar el fichero `appsettings.json` con un par de claves pública/privada
que puede ser obtenida en https://developer.marvel.com/

## Tests
El proyecto incluye un proyecto de tests hechos con xUnit. Tras compilar
deberían aparecer todos los tests en la ventana 'Explorador de Pruebas' de Visual Studio.

## iOS
Por limitaciones en la versión de Visual Studio usada, se incluye un
proyecto vacío para iOS ya que se ha eliminado el soporte para edición
de vistas de iOS en VS para Windows (https://docs.microsoft.com/es-es/xamarin/ios/user-interface/storyboards/).

## Características que faltan
Algunas características que quisiera haber implementado:
- Cacheo de imágenes y peticiones al API (usando SQLite, Realm, Monkey-Cache o algún otro)
- Uso de Fragments para manejar la navegación desde la vista de búsqueda a la de detalles
- Throttle del input al buscar, para ahorrar peticiones
- Mejor manejo de errores
- Mejor diseño