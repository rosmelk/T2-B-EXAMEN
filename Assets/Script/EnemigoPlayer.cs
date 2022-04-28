using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    
   public float balas_disparadas = 0;  //Balas disparadas y que le han dado al enemigo.
   public float balas_necesarias = 5; //Las balas que se necesitan para matar al enemigo.
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var tag = col.gameObject.tag;
        if (tag == "bala")
        {
            balas_disparadas += 1; //Suma 1 a las balas disparadas.
            Destroy(col.gameObject);//Destruye la bala.
            if (balas_necesarias == balas_disparadas)//Si han tocado al jugador el número de balas necesarias.
            {
            
                Destroy(this.gameObject);//Destruye este objeto.
           
            }
        }
        
    }
    
}
