using System.Collections;

public interface ISpawner
{
    // Método que cada spawner debe implementar
    IEnumerator StartWave(int waitingTime);
}
