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
## Jugabilidad
### _Game Loop_

* **Fase 1:** El jugador selecciona un proyecto para proponer a sus ministros.
* **Fase 2:** Los ministros votan por la aprobación de la propuesta.
* **Fase 3:** El jugador analiza los resultados de la votación y decide qué cambios debe hacer a su gabinete.
* **Fase 4:** El jugador reforma o cambia a sus ministros.
## Mecánicas
*   **Proponer Proyecto:** El jugador puede escoger un proyecto de una lista para proponer a sus ministros. Solamente aquellos proyectos que no sean de la alineamiento dominante del gabinete pueden ser propuestos.
*   **Adoctrinar:** _a.k.a._ Reformar
*   **Cambiar:**
# 5. Historia y Narrativa
# 6. Niveles y progresión
# 7. Interfaces
# 8. Propuesta de audio
# 9. Propuesta Visual
El juego tendrá un estilo _low-poly_
# 10. Bitácora de Iteraciones
## Prototipo 1
El objetivo de este primer prototipo es descubrir y probar el _core loop_, implementando, completando, y desafiando las ideas propuestas en la fase inicial del proyecto. Se omiten algunas funciones planeadas en virtud del tiempo.

El prototipo consta de una sola pantalla que tiene un rectángulo café emulando una mesa, con siete ministros alrededor representados por círculos. Sobre la mesa hay ocho botones que representan cada proyecto. Los puestos de los ministros están nominados según su posición relativa a la mesa; a las 12 está el puesto `A`, y luego siguen secuencialmente en la dirección de las manillas del reloj. Los ministros y los proyectos están etiquetados por color, de tal forma que su alineamiento sea inmediatamente distinguible.

![Prototipo 1 c/ anotaciones](.\MiscArt\Prototipo 1.png)

El jugador gana cuando logra hacer **tres proyectos de cada tipo**, _i.e._ tres proyectos económicos, tres humanistas, y tres patriotas.

<!--¿Y cómo pierdo?-->

* **Etapa 0:**  
  Se generan **7 ministros**, con nombres y alineaciones aleatorios.
  Se generan además **8 proyectos** aleatoriamente de todas las alineaciones. Aquellos que sean de la misma alineamiento que la alineamiento dominante del gabinete son inelegibles. Ej: Si 4/7 ministros son económicos, entonces los proyectos de tipo económicos no son elegibles.
  
* **Etapa 1:**  
  El jugador escoge el proyecto que desea proponer.

* **Etapa 2:**  
  [AUTOMÁTICO] Los ministros votan por los proyectos. Si el ministro es del mismo alineamiento que el proyecto, entonces aprueba la propuesta. Si no lo es, vota al azar con una probabilidad de 50/50.
  La aprobación se determina por mayoría de votos. Si hay un empate se repita le votación. Si vuelve a haber un empate se rechaza la propuesta.

* **Etapa 3:**  
  El jugador analiza los resultados de la votación e identifica si desea cambiar un ministro. En esta iteración toda la información respecto a la votación es pública.

* **Etapa 4:**  
  El jugador cambia a uno de los ministros si así lo desea. En este prototipo no existe la mecánica de [adoctrinar](#habilidades-del-jugador).
  <!--¿Sólo a uno?-->
  <!--¿Reroll o elige alineamiento?-->

# 11. Extras
# 12. Referencias
# 13. _Assets_ externos
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

