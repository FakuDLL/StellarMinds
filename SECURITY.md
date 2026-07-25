# Política de seguridad

## Versiones con soporte

Este repositorio mantiene únicamente la rama `main`. Las correcciones de seguridad se aplican sobre la versión más reciente.

## Reportar una vulnerabilidad

No publiques credenciales, datos personales ni detalles explotables en un issue.

Usá la opción **Security > Report a vulnerability** del repositorio para enviar un reporte privado. Incluí:

- una descripción clara del problema;
- los pasos mínimos para reproducirlo;
- el impacto esperado;
- una propuesta de corrección, si la tenés.

## Gestión de secretos

El repositorio no necesita ni acepta secretos versionados. Para ejecutar el proyecto:

- en desarrollo, usá .NET User Secrets;
- en producción, usá variables de entorno o un gestor de secretos;
- ante una exposición accidental, revocá o rotá la credencial antes de eliminarla del historial.

Los archivos de configuración incluidos sólo contienen valores locales o vacíos. Nunca deben usarse las cuentas y datos de precarga como configuración de producción.
