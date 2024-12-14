
Descripción del Proyecto:

Este proyecto es un juego de estilo shoot'em up inspirado en títulos como Gradius. Mi objetivo con este proyecto fue crear un juego desafiante con una jugabilidad fluida, introduciendo mecánicas originales y complejas que ofrecen una experiencia divertida, a la vez que aprovecho conceptos como el object pooling y singleton para optimizar el rendimiento.

Mecánicas y Desafíos:

En este proyecto, enfrenté varios desafíos, en especial en áreas que nunca antes había abordado, como el movimiento de los enemigos en relación al ángulo del spawner. Esta mecánica resultó ser especialmente interesante porque necesitaba calcular la orientación de los enemigos de manera dinámica, lo que requirió el uso de cálculos trigonométricos y un control más preciso sobre el comportamiento de los enemigos.

Otro aspecto que me costó bastante trabajo fue la implementación del boss. Mi interés en este proyecto fue especialmente en las mecánicas y la complejidad de la jugabilidad, y la creación de un jefe al final del nivel fue uno de los momentos que más disfruté. El boss tiene patrones de movimiento y ataques que introducen un reto significativo para el jugador, lo que permite ofrecer una experiencia única.

Enfoque y Estilo de Desarrollo:

Aunque he hecho un esfuerzo por explicar cada parte del código y sus mecanismos, debo mencionar que no comento demasiado el código. Esta es una costumbre personal con la que estoy trabajando para mejorar. Sin embargo, para remediar esta falta de comentarios, a continuación resalto algunos de los puntos clave del proyecto:

Object Pooling: He utilizado esta técnica para gestionar los objetos que aparecen y desaparecen durante el juego, como los enemigos y los power-ups. Esto mejora el rendimiento y reduce la carga de creación y destrucción de objetos durante el juego.

Singleton: Utilizo el patrón Singleton en situaciones específicas para asegurar que solo haya una instancia de ciertos objetos, como el GameOverManager. Esto permite gestionar el estado del juego de manera eficiente y evitar la duplicación de lógica innecesaria.

Reutilización de Código: He trabajado para que el código sea modular y reutilizable. Esto me ha permitido reducir redundancias y hacer que las mecánicas sean más fáciles de gestionar y actualizar.

Diseño de la Jugabilidad:

Mi deseo con la jugabilidad era hacer algo similar al estilo de Gradius, pero con diferencias claras. Por ejemplo, la dirección de los enemigos no sigue patrones clásicos, sino que cambia según el ángulo del spawner, lo que crea situaciones impredecibles y desafiantes para el jugador.

Adicionalmente, decidí incluir un boss al final del primer nivel como una forma de ofrecer un reto significativo al jugador. La primera parte del juego está pensada como una zona de adaptación para que los jugadores puedan aprender los controles y mecánicas antes de enfrentarse al jefe.

Interfaz de Usuario:

La interfaz no es mi especialidad, así que intenté mantenerla lo más simple y funcional posible. El diseño busca proporcionar la información necesaria al jugador sin sobrecargar la pantalla, enfocándome en mostrar solo los elementos esenciales como la vida, las puntuaciones y los recursos disponibles.

Conclusión
En resumen, este proyecto me ha permitido aprender y experimentar con diversas mecánicas y patrones de diseño que no había utilizado antes. Mi objetivo siempre fue lograr una jugabilidad desafiante y divertida, y aunque algunas áreas (como la interfaz) no son mi fuerte, estoy satisfecho con los resultados obtenidos.
