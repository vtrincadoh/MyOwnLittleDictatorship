***

# ***My own little dictatorship***

***
The Jiharing Studio
Paralelo 2 - Taller de creación de videojuegos

Vicente Trincado
Sebastián Meneses


# Tabla de contenidos
[TOC]

# 1. Pitch
Eres un dictador y añoras que tu pueblo te idolatre. Para esto, realizarás proyectos y modificaras tu gabinete para que no obstaculicen tu objetivo.

# 2. Descripción General
Eres un dictador que tiene como objetivo ser idolatrado por su gente, por lo que el jugador realizará distintos proyectos con este fin. El problema es que tu gabinete de ministros podrá oponerse a tus decisiones, por lo que puedes realizar distintas acciones para evitar estos impedimentos (cada acción tendrá su propia consecuencia). Ganar significa realizar una cantidad de proyectos, lo que hará finalmente que tu pueblo te idolatre, mientras que perderás si todos tus ministros se rebelan contra ti.

# 3. Jugabilidad y Mecánicas
## 3.1. _Core Gameplay_

_My own little dictatorship_ es un juego de estrategia, donde se espera que el jugador adquiera la habilidad de modificar constantemente un gabinete de ministros con el propósito de mejorar sus posibilidades de aprobar un proyecto de gobierno. El *Core Loop* se divide principalmente en cuatro etapas:

* **Etapa 1:** El jugador selecciona un proyecto para proponer a sus ministros.
* **Etapa 2:** Los ministros votan por la aprobación de la propuesta.
* **Etapa 3:** El jugador analiza los resultados de la votación y decide qué cambios debe hacer a su gabinete.
* **Etapa 4:** El jugador reforma o cambia a sus ministros.
## 3.2. Mecánicas
* **Proponer Proyecto:** El jugador puede escoger un proyecto de una lista para proponer a sus ministros. Solamente aquellos proyectos que no sean del alineamiento dominante del gabinete pueden ser propuestos.

* **Reformar `reform`:** _a.k.a. Adoctrinar_. Modifica a un ministro sin cambiarlo por otro [WIP].

* **Cambiar:** Elimina a uno de los ministros de un puesto, y lo cambia por otro con un alineamiento distinto.


## 3.3. Unidades
### Ministro
#### Atributos

* **Nombre `name`:** _string_ Nombre y apellido del ministro. Generados aleatoriamente junto con el ministro. Su propósito es únicamente estético, no afecta la funcionalidad. Ej: "Roberto Pérez".

* **Puesto `seat`:** _enum_ Posición del ministro relativo a la mesa. Los enumeradores son letras mayúsculas que siguen la secuencia `A, B, C, ...`. A las 12 está el puesto `A`, y luego siguen secuencialmente en la dirección de las manillas del reloj. _A la fecha[\*](#9.1.-prototipo-1---Oct-w3)_, su propósito es de organización interna.

* **Cordura `sanity`:** _float_ Porcentaje que determina qué tan cuerdo es el ministro. El jugador pierde cuando todos [WIP] los ministros alcanzan el máximo de su cordura, por lo que el jugador siempre querrá mantener sus ministros lo menos cuerdos posible. Al generar un ministro, este inicia con un valor de cordura aleatorio entre 35-55% [WIP].

* **Alineamiento `alignment`:** _enum_ Preferencia de votación del ministro. Para más información ver <!--¿Ver qué?-->.

#### Métodos
* **Votar `Vote`:** _void_ Ministro vota respecto a la propuesta de proyecto. Si el proyecto es del mismo alineamiento del ministro, éste se aprueba automáticamente. _A la fecha[\*](#9.1.-prototipo-1---Oct-w3)_, si el proyecto no es del mismo alineamiento el ministro voltea una moneda.

### Proyecto

#### Atributos

* **Nombre `name`:** _string_ Nombre del proyecto. _A la fecha[\*](#9.1.-prototipo-1---Oct-w3)_, se genera automáticamente. Propósito estético. A futuro estará asociado al alineamiento del proyecto. Ej: "Plaza de la nación", "Estadio del líder supremo", etc.
* **Nivel `level`:** No implementado aún. Ver [Prorgesión](#6. niveles-y-progresión). <!--Mentira, eso no existe todavía-->
* **Alineamiento `alignment`: **_enum_ Tipo de proyecto. Asociado a las preferencias de los ministros. Para más información ver <!--¿Ver qué?-->.

# 4. Historia y Narrativa
# 5. Niveles y progresión
# 6. Interfaces
# 7. Propuesta de audio
# 8. Propuesta Visual
El juego tendrá un estilo _low-poly_
# 9. Bitácora de Iteraciones
## 9.1. Prototipo 1 - Oct w3
El objetivo de este primer prototipo es descubrir y probar el _core loop_, implementando, completando, y desafiando las ideas propuestas en la fase inicial del proyecto. Se omiten algunas funciones planeadas en virtud del tiempo.

El prototipo consta de una sola pantalla que tiene un rectángulo café emulando una mesa, con siete ministros alrededor representados por círculos. Sobre la mesa hay ocho botones que representan cada proyecto. Los puestos de los ministros están nominados según su posición relativa a la mesa; a las 12 está el puesto `A`, y luego siguen secuencialmente en la dirección de las manillas del reloj. Los ministros y los proyectos están etiquetados por color, de tal forma que su alineamiento sea inmediatamente distinguible. Al proponer un proyecto se registran los votos de cada uno de los ministros en una sección a la derecha de la mesa.

![Prototipo 1 c/ anotaciones](MiscArt/Prototipo%201.png)

El jugador gana cuando logra hacer **dos proyectos de cada tipo**, _i.e._ dos proyectos económicos, dos humanistas, y dos patriotas.  Por otro lado, el jugador pierde cuando **se llena completamente** la barra de [cordura](#ministro) de todos sus ministros.

<!--No me convece-->

* **Etapa 0:**  
  Se generan **7 ministros**, con nombres y alineaciones aleatorios.
  Se generan además **8 proyectos** aleatoriamente de todas las alineaciones. Aquellos que sean de la misma alineamiento que la alineamiento dominante del gabinete son inelegibles. Ej: Si 4/7 ministros son económicos, entonces los proyectos de tipo económicos no son elegibles.
  
* **Etapa 1:**  
  El jugador escoge el proyecto que desea proponer.

* **Etapa 2:**  
  [AUTOMÁTICO] Los ministros votan por los proyectos. Si el ministro es del mismo alineamiento que el proyecto, entonces aprueba la propuesta. Si no lo es, vota al azar con una probabilidad de 50/50. Este último es un comportamiento único a esta iteración.
  La aprobación se determina por mayoría de votos. Si hay un empate se repita le votación. Si vuelve a haber un empate se rechaza la propuesta.

* **Etapa 3:**  
  El jugador analiza los resultados de la votación e identifica si desea cambiar un ministro. En esta iteración toda la información respecto a la votación es pública.

* **Etapa 4:**  
  El jugador cambia a solo uno de los ministros si así lo desea. Al cambiar un ministro se hace un _reroll_ y se decide aleatoriamente el nuevo alineamiento. En este prototipo no existe la mecánica de [adoctrinar](#mecánicas).
  <!--¿Sólo a uno?-->
  <!--¿Reroll o elige alineamiento?-->

# 10. Extras
# 11. Referencias
# 12. _Assets_ externos
[JSON .NET For Unity](https://assetstore.unity.com/packages/tools/input-management/json-net-for-unity-11347)  
[Full Menu System](https://assetstore.unity.com/packages/tools/gui/full-menu-system-free-158919)  
[Voxel Wooden Funiture](https://assetstore.unity.com/packages/3d/props/furniture/voxel-wooden-funiture-67811)  
[City Voxel Pack](https://assetstore.unity.com/packages/3d/environments/urban/city-voxel-pack-136141)  
[Low Poly Office Props - LITE](https://assetstore.unity.com/packages/3d/environments/low-poly-office-props-lite-131438)  
[Snaps Prototype | Office](https://assetstore.unity.com/packages/3d/environments/snaps-prototype-office-137490)  
[Cartoon Low Poly City Pack Lite](https://assetstore.unity.com/packages/3d/environments/urban/cartoon-low-poly-city-pack-lite-166617)  
[Lowpoly Modern City Buildings Set](https://assetstore.unity.com/packages/3d/environments/urban/lowpoly-modern-city-buildings-set-64427)  
[Low Poly Storage Pack](https://assetstore.unity.com/packages/3d/environments/urban/low-poly-storage-pack-101732)  
[Low Poly Road Pack](https://assetstore.unity.com/packages/3d/environments/roadways/low-poly-road-pack-67288)  

