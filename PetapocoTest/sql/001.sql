CREATE TABLE REG_NivelSeveridad (IdNivelSeveridad BIGINT NOT NULL IDENTITY, Nombre VARCHAR(10) NOT NULL, Descripcion VARCHAR(200) NOT NULL, CONSTRAINT REG_NivelSeveridad_PK PRIMARY KEY (IdNivelSeveridad));
CREATE TABLE REG_Regla (IdRegla BIGINT NOT NULL, IdNivelSeveridad BIGINT NOT NULL, Nombre VARCHAR(100) NOT NULL, Descripcion VARCHAR(MAX), CONSTRAINT REG_Regla_PK PRIMARY KEY (IdRegla));
CREATE TABLE TablaPrueba(IdTablaPrueba BIGINT NOT NULL IDENTITY, Descripcion VARCHAR(100) COLLATE Modern_Spanish_CI_AS, IdNivelSeveridad BIGINT, CONSTRAINT TablaPrueba_PK PRIMARY KEY (IdTablaPrueba), CONSTRAINT TablaPrueba_fk1 FOREIGN KEY (IdNivelSeveridad) REFERENCES REG_NivelSeveridad (IdNivelSeveridad));

SET IDENTITY_INSERT REG_NivelSeveridad ON;
INSERT INTO REG_NivelSeveridad (IdNivelSeveridad, Nombre, Descripcion) VALUES (1, 'Bloqueante', 'Riesgo operacional/seguridad: Este problema puede volver inestable a toda la aplicación en producción');
INSERT INTO REG_NivelSeveridad (IdNivelSeveridad, Nombre, Descripcion) VALUES (2, 'Crítica', 'Riesgo operacional/seguridad: Este problema puede llevar a un comportamiento inesperado en producción sin impactar la integridad de toda la aplicación');
INSERT INTO REG_NivelSeveridad (IdNivelSeveridad, Nombre, Descripcion) VALUES (3, 'Mayor', 'Este problema puede tener un impacto sustancial en la productividad');
INSERT INTO REG_NivelSeveridad (IdNivelSeveridad, Nombre, Descripcion) VALUES (4, 'Menor', 'Este problema puede tener un impacto potencial o menor en la productividad');
INSERT INTO REG_NivelSeveridad (IdNivelSeveridad, Nombre, Descripcion) VALUES (5, 'Info', 'Riesgo de seguridad o impacto en la productividad desconocido o no bien definido');
SET IDENTITY_INSERT REG_NivelSeveridad OFF;


INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (1, 3, 'No se permite el uso de DataContracts en la capa de datos', '<p>La capa de datos sólo debe manejar entidades de base de datos y tipos primitivos.</p>
<p>Por este motivo, no puede haber clases de DataContract ni referencias a su namespace.</p>
<p>El mapping entre DataContract y Entidad, en cualquier dirección, se debe realizar en el Negocio. El paso de parámetros debe ser con datos primitivos.</p>
<p>El siguiente código está prohibido, ya que recibe como parámetro un DataContract:</p>
<pre>
<samp>
public static List&lt;ModuloDtc&gt; ObtenerModulosPorCJuridica(TipoPersonalidadJuridicaDtc cJuridica)
{
    ...
}
</samp>
</pre>
<p>El siguiente código está prohibido, ya que retorna un DataContract:</p>
<pre>
<samp>
public static List&lt;ModuloDtc&gt; ObtenerModulosPorCJuridica(int cJuridicaId)
{
    ...
}
</samp>
</pre>');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (2, 3, 'Todas las clases de la capa de datos deben tener sufijo "Datos"', 'El nombre de la clase:
<pre>
<samp>
public class Proveedor
{
  ...
}
</samp>
</pre>

debería escribirse como:
<pre>
<samp>
public class ProveedorDatos
{
  ...
}
</samp>
</pre>
');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (3, 2, 'Los envíos por POST deben usar el AntiForgeryToken', '<p>Para evitar que se envíen datos POST desde otro servidor, se debe incluir y validar en los POST un AntiForgeryToken.</p>
<p>Dentro de los formularios que hacen POST, agregar:</p>
<pre>
<samp>@using (Ajax.BeginForm(...))
{
    @Html.AntiForgeryToken()
    ...
}</samp>
</pre>
<p>Dentro de los jquery que usan POST, agregar:</p>
<pre>
<samp>$.post(''@Url.Content("~/ConsultaAscensores/TraerComunas")'',
    { idRegion: $("#comboRegiones").val(),
      __RequestVerificationToken: $("input[name=__RequestVerificationToken]").val(),
      ...
    },
    ...
</samp>
</pre>
<p>En el caso de jquery, de todos modos hay que agregar @Html.AntiForgeryToken para que se incluya la cookie en el navegador y se pueda enviar por el $.post</p>');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (4, 3, 'No se debe acceder al contexto de la base de datos', '<p>Para acceder a la base de datos se debe realizar por medio de la capa de datos.</p>
<p>Por esto no se permite el uso del contexto en cualquier otra capa que no sea la de Datos.</p>
<p>El siguiente código está prohibido:</p>
<pre>
<samp>
public class ModulosNegocio
{
    public static List<MODULO> ObtenerModulosCJuridica(TipoPersonalidadJuridicaDtc cJuridica)
    {
        ...
        BaseEntities contexto = new BaseEntities();
        ...
    }
}
</samp>
</pre>');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (5, 2, 'Los métodos públicos deben recibir MensajeRespuesta como referencia', '<p>MensajeRespuesta debe pasarse como referencia para que el invocador del negocio reciba el valor actualizado aunque no se retorne el parámetro.</p>
<p>El siguiente código:</p>
<pre>
<samp>public static String IngresarDenuncia(DenunciaDtc denuncia, MensajeRespuesta resultado)
{
    ...
}</samp>
</pre>

<p>debería escribirse como:</p>
<pre>
<samp>public static String IngresarDenuncia(DenunciaDtc denuncia, ref MensajeRespuesta resultado)
{
    ...
}</samp>
</pre>
');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (6, 2, 'Los métodos públicos deben asignar valor a MensajeRespuesta', '<p>En el negocio se debe asignar un valor a MensajeRespuesta.</p>
<p>El siguiente código:</p>
<pre>
<samp>public static String IngresarDenuncia(DenunciaDtc denuncia, ref MensajeRespuesta resultado)
{
    return "Vas por el mal camino";
}</samp>
</pre>

<p>debería escribirse como:</p>
<pre>
<samp>public static String IngresarDenuncia(DenunciaDtc denuncia, ref MensajeRespuesta resultado)
{
    resultado = ServicioRespuesta.EXITO;
    return "Vas por el buen camino";
}</samp>
</pre>
');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (7, 3, 'Los métodos públicos no pueden retornar entidades de BBDD', '<p>Los métodos públicos serán accedidos por los servicios web, por lo que no pueden retornar un objeto de la capa de datos.</p>
<p>Está permitidos: "string", "int", "int32", "int16", "int64", "bool", "boolean", "long", "double", "short", "byte", "decimal", "date", "datetime", "char", "*Dtc".
<p>El siguiente código:</p>
<pre>
<samp>public static REG_Region IngresarDenuncia(...){</samp>
</pre>

<p>debería escribirse como:</p>
<pre>
<samp>public static RegionDtc IngresarDenuncia(...){</samp>
</pre>
');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (8, 4, 'Las clases de constantes deben estar en el directorio de Constantes', '<p>Si una clase tiene el sufijo "Constantes" debe estar dentro del directorio "Constantes".</p>
<p>La siguiente estructura de directorio:</p>
<pre><samp><ul class="sin">
  <li>+- Constantes\</li>
  <li>+- Contracts\</li>
  <li>+- Enumeradores\</li>
  <li>-- SistemaConstantes.cs</li>
</ul></samp>
</pre>

<p>debería quedar como:</p>
<pre><samp><ul class="sin">
  <li>+- Constantes\</li>
  <li style="padding-left: 16pt">|- SistemaConstantes.cs</li>
  <li>+- Contracts\</li>
  <li>+- Enumeradores\</li>
</ul></samp>
</pre>
');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (9, 3, 'Las clases de constantes deben tener sufijo "Constantes"', '<p>Todas las clases dentro del directorio "Constantes" debe tener el sufijo "Constantes". Tanto el archivo como la clase declarada en su interior.</p>
<p>La siguiente estructura de directorio:</p>
<pre><samp><ul class="sin">
  <li>+- Constantes\</li>
  <li style="padding-left: 16pt">|- Sistema.cs</li>
  <li>+- Contracts\</li>
  <li>+- Enumeradores\</li>
</ul></samp>
</pre>

<p>debería quedar como:</p>
<pre><samp><ul class="sin">
  <li>+- Constantes\</li>
  <li style="padding-left: 16pt">|- SistemaConstantes.cs</li>
  <li>+- Contracts\</li>
  <li>+- Enumeradores\</li>
</ul></samp>
</pre>
');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (10, 3, 'Los campos de las constantes deben tener el modificador "const"', '<p>Para declarar un campo como una constantes debe tener el modificador "const".</p>
<p>El siguiente código:</p>
<pre>
<samp>public String PERSONA_NATURAL = "Persona Natural";</samp>
</pre>

<p>debería escribirse como:</p>
<pre>
<samp>public const String PERSONA_NATURAL = "Persona Natural";</samp>
</pre>
');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (11, 4, 'Los campos de las constantes deben estar en mayúsculas', '<p>Para declarar un campo como una constantes debe tener el modificador "const".</p>
<p>El siguiente código:</p>
<pre>
<samp>public const String Persona_Natural = "Persona Natural";</samp>
</pre>

<p>debería escribirse como:</p>
<pre>
<samp>public const String PERSONA_NATURAL = "Persona Natural";</samp>
</pre>
');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (12, 3, 'Los campos de las constantes deben ser públicas', '<p>Para que se pueda acceder a los campos que son constantes deben tener el modificador <em>public</em></p>
<p>El siguiente código:</p>
<pre>
<samp>public class SistemaConstantes
{
    private const String MODELO_ERROR = "ModeloError";
}</samp>
</pre>

<p>debería escribirse como:</p>
<pre>
<samp>public class SistemaConstantes
{
    public const String MODELO_ERROR = "ModeloError";
}</samp>
</pre>


');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (13, 3, 'Las clases de constantes deben seguir el Principio de responsabilidad única', '<p>Se permiten 30 constantes como máximo dentro de una única clase de constantes.</p>
<p>Si una clase posee más de esa cantidad, es probable que tenga más de una responsabilidad.</p>
<p>La solución es separar constantes en distintos archivos agrupándolas según su contexto.</p>');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (14, 4, 'Las clases de enumeradores deben estar en el directorio de Enumeradores', '<p>Si una clase tiene el sufijo "Enum" debe estar dentro del directorio "Enumeradores".</p>
<p>La siguiente estructura de directorio:</p>
<pre><samp><ul class="sin">
  <li>+- Constantes\</li>
  <li>+- Contracts\</li>
  <li>+- Enumeradores\</li>
  <li>-- SistemaEnum.cs</li>
</ul></samp>
</pre>

<p>debería quedar como:</p>
<pre><samp><ul class="sin">
  <li>+- Constantes\</li>
  <li>+- Contracts\</li>
  <li>+- Enumeradores\</li>
  <li style="padding-left:16pt">|- SistemaEnum.cs</li>
</ul></samp>
</pre>
');
INSERT INTO REG_Regla (IdRegla, IdNivelSeveridad, Nombre, Descripcion) VALUES (15, 3, 'Las clases de enumeradores deben tener sufijo "Enum"', '<p>Todas las clases dentro del directorio "Enumeradores" debe tener el sufijo "Enum". Tanto el archivo como la clase declarada en su interior.</p>
<p>La siguiente estructura de directorio:</p>
<pre><samp><ul class="sin">
  <li>+- Constantes\</li>
  <li>+- Contracts\</li>
  <li>+- Enumeradores\</li>
  <li style="padding-left:16pt">|- Sistema.cs</li>
</ul></samp>
</pre>

<p>debería quedar como:</p>
<pre><samp><ul class="sin">
  <li>+- Constantes\</li>
  <li>+- Contracts\</li>
  <li>+- Enumeradores\</li>
  <li style="padding-left:16pt">|- SistemaEnum.cs</li>
</ul></samp>
</pre>
');