using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnvInstantiator : MonoBehaviour {

    public List<GameObject> env_prefabs = new List<GameObject>();
    public List<GameObject> closing_prefabs = new List<GameObject>();

    public List<GameObject> env_reduced = new List<GameObject>();


    private Object[] ressources_tmp_load;

    int ID_count=0;

    public GameObject player;
    env current_env,previous_env;

    public struct env
    {
        public GameObject plane;
        public bool G, H, D, B;
        public bool prox_G,prox_H,prox_D,prox_B;
        public Vector3 coord;
        public bool visited;
        public int ID;
    }

    public List<env> envs = new List<env>();

    // Use this for initialization
    void Start () {
        // ------------------------ Load environnement prefabs from Assets/Resources/envs folder ------------------------ //
        ressources_tmp_load = Resources.LoadAll("envs");
        foreach (GameObject tmp in ressources_tmp_load)
        {
            env_prefabs.Add(tmp);
        }


        ressources_tmp_load = Resources.LoadAll("closings");
        foreach (GameObject tmp in ressources_tmp_load)
        {
            closing_prefabs.Add(tmp);
        }

        // ------------------------------------------------------------------------------------------------------------- //

        add_first_env();
    }

    // Update is called once per frame
    void Update () {
        
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    player.transform.Translate(new Vector3(-10F, 0, 0));
        //    foreach (env env_created in envs)
        //    {
        //        if (player.transform.position.x == env_created.coord.x && player.transform.position.z == env_created.coord.z) // A CHANGER
        //        {
        //            current_env = env_created;
        //            if (previous_env.ID != current_env.ID)
        //            {
        //              //  Debug.Log(current_env.plane.name);
        //                previous_env = current_env;
        //            }
        //        }
        //    }
        //    call_add();

        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    player.transform.Translate(new Vector3(0, 0, 10F));
        //    foreach (env env_created in envs)
        //    {
        //        if (player.transform.position.x == env_created.coord.x && player.transform.position.z == env_created.coord.z) // A CHANGER
        //        {
        //            current_env = env_created;
        //            if (previous_env.ID != current_env.ID)
        //            {
        //               // Debug.Log(current_env.plane.name);
        //                previous_env = current_env;
        //            }
        //        }
        //    }
        //    call_add();

        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    player.transform.Translate(new Vector3(10F, 0, 0));
        //    foreach (env env_created in envs)
        //    {
        //        if (player.transform.position.x == env_created.coord.x && player.transform.position.z == env_created.coord.z) // A CHANGER
        //        {
        //            current_env = env_created;
        //            if (previous_env.ID != current_env.ID)
        //            {
        //              //  Debug.Log(current_env.plane.name);
        //                previous_env = current_env;
        //            }
        //        }
        //    }
        //    call_add();

        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    player.transform.Translate(new Vector3(0, 0, -10F));
        //    foreach (env env_created in envs)
        //    {
        //        if (player.transform.position.x == env_created.coord.x && player.transform.position.z == env_created.coord.z) // A CHANGER
        //        {
        //            current_env = env_created;
        //            if (previous_env.ID != current_env.ID)
        //            {
        //               // Debug.Log(current_env.plane.name);
        //                previous_env = current_env;
        //            }
        //        }
        //    }
        //    call_add();
        //}

    }

    void call_from_trigger()
    {

    }

    public void call_add(Vector3 coord_caller)
    {
        //Debug.Log(coord_caller);
        // Debug.Log(("call_ad_cross from : "+current_env.plane.name+ " at "+current_env.coord));
        foreach (env env_created in envs)
        {
            if (coord_caller.x == env_created.coord.x && coord_caller.z == env_created.coord.z)
            {
                current_env = env_created;
                if (previous_env.ID != current_env.ID)
                {
                    // Debug.Log(current_env.plane.name);
                    previous_env = current_env;
                }
            }
        }

        if (!current_env.visited)
        {
            add_env_cross(current_env);
        }
        current_env.visited = true;


        //int G = -1, D = -1, B = -1, H = -1;
        //int list_indic = 0;
        //foreach (env env_created in envs)
        //{
        //    if (env_created.coord.x == current_env.coord.x - 10 && env_created.coord.z == current_env.coord.z) // check if env déjà présent à gauche 
        //    {
        //        //add_env_cross(env_created);
        //        G = list_indic;
        //    }
        //    if (env_created.coord.x == current_env.coord.x + 10 && env_created.coord.z == current_env.coord.z) // check if env déjà présent à droite 
        //    {
        //        //add_env_cross(env_created);
        //        D = list_indic;

        //    }
        //    if (env_created.coord.x == current_env.coord.x && env_created.coord.z == current_env.coord.z - 10) // check if env déjà présent en bas 
        //    {
        //        //add_env_cross(env_created);
        //        H = list_indic;

        //    }
        //    if (env_created.coord.x == current_env.coord.x && env_created.coord.z == current_env.coord.z + 10) // check if env déjà présent en haut 
        //    {
        //        //add_env_cross(env_created);
        //        B = list_indic;

        //    }
        //    list_indic++;
        //}

        //if (G != -1 && !envs.ElementAt(G).visited)
        //{
        //    add_env_cross(envs.ElementAt(G));
        //}
        //if (D != -1 && !envs.ElementAt(D).visited)
        //{
        //    add_env_cross(envs.ElementAt(D));
        //}
        //if (H != -1 && !envs.ElementAt(H).visited)
        //{
        //    add_env_cross(envs.ElementAt(H));
        //}
        //if (B != -1 && !envs.ElementAt(B).visited)
        //{
        //    add_env_cross(envs.ElementAt(B));
        //}

    }

    void add_first_env()
    {
        env first_env = new env();
        // initialise proxi bools
        first_env.prox_G = false;
        first_env.prox_H = false;
        first_env.prox_D = false;
        first_env.prox_B = false;

        first_env.plane = env_prefabs[Random.Range(0, env_prefabs.Count)];


        Debug.Log(first_env.plane.name);

        //----------------------------------------- set bools -----------------------------------------//
        if (first_env.plane.name.Contains("G"))
            first_env.G = true;
        else
            first_env.G = false;

        if (first_env.plane.name.Contains("H"))
            first_env.H = true;
        else
            first_env.H = false;

        if (first_env.plane.name.Contains("D"))
            first_env.D = true;
        else
            first_env.D = false;

        if (first_env.plane.name.Contains("B"))
            first_env.B = true;
        else
            first_env.B = false;
        //------------------------------------------------------------------------------------------//

        first_env.coord = new Vector3(0, 0, 0);
        first_env.visited = true;
        first_env.ID = ID_count;
        ID_count++;
        Instantiate(first_env.plane, first_env.coord, Quaternion.Euler(0, 180, 0));

        envs.Add(first_env);
        current_env = first_env;

        add_env_cross(current_env);

    }







    void add_env_cross(env current_env)
    {
        bool already_G=false, already_H=false, already_D=false, already_B=false; 
        foreach (env env_created in envs) // vérifier si les cases à ajouter autour de la case appelante n'existe pas déjà
        {
            if (env_created.coord.x == current_env.coord.x-10 && env_created.coord.z == current_env.coord.z) // check if env déjà présent à gauche 
            {
                already_G = true;
            }
            if (env_created.coord.x  == current_env.coord.x+10 && env_created.coord.z == current_env.coord.z) // check if env déjà présent à droite 
            {
                already_D = true;
            }
            if (env_created.coord.x == current_env.coord.x && env_created.coord.z == current_env.coord.z-10) // check if env déjà présent en bas 
            {
                already_B = true;
            }
            if (env_created.coord.x == current_env.coord.x && env_created.coord.z == current_env.coord.z+10) // check if env déjà présent en haut 
            {
                already_H = true;
            }
        }

        // -------------------------------------- création de l'env à gauche de la case appelante ---------------------------------------//
        if (current_env.G && !already_G) // si une ouverture à gauche
        {
            string str_prox_G = "", str_prox_H = "", str_prox_D = "", str_prox_B = "";
            string char_restrict_1="", char_restrict_2 = "", char_restrict_3 = "",char_delete_1="FFFFFF", char_delete_2 = "FFFFFF",char_delete_3 = "FFFFFF";

            env new_env = new env();
            new_env.coord = current_env.coord;
            new_env.coord.x -= 10;

            // set proxi bools
            new_env.prox_G = false;
            new_env.prox_H = false;
            new_env.prox_D = true;
            new_env.prox_B = false;

            foreach (env env_created in envs) // on vérifie les cases en croix autour de la case que l'on va rajouter à gauche
            {
                if (env_created.coord.x  == new_env.coord.x-10 && env_created.coord.z == new_env.coord.z) // check if env déjà présent à gauche 
                {
                    str_prox_G = env_created.plane.name;
                    new_env.prox_G = true;
                }
                if (env_created.coord.x  == new_env.coord.x+10 && env_created.coord.z == new_env.coord.z) // check if env déjà présent à droite 
                {
                    str_prox_D = env_created.plane.name;
                    new_env.prox_D = true;
                }
                if (env_created.coord.x == new_env.coord.x && env_created.coord.z  == new_env.coord.z-10) // check if env déjà présent en bas 
                {
                    str_prox_B = env_created.plane.name;
                    new_env.prox_B = true;
                }
                if (env_created.coord.x == new_env.coord.x && env_created.coord.z  == new_env.coord.z+10) // check if env déjà présent en haut 
                {
                    str_prox_H = env_created.plane.name;
                    new_env.prox_H = true;
                } 
            }




            if (new_env.prox_G) // une case existe à gauche de là où on veut créer // should use new_env_X 
            {
                if (str_prox_G.Contains("D"))
                {
                    char_restrict_1 = "G";
                }
                else
                {
                    char_delete_1 = "G";
                }
            }

            if (new_env.prox_H) // une case existe en haut de là où on veut créer
            {
                if (str_prox_H.Contains("B"))
                {
                    char_restrict_2 = "H";
                }
                else
                {
                    char_delete_2 = "H";
                }
            }

            if (new_env.prox_B) // une case existe en bas de là où on veut créer
            {
                if (str_prox_B.Contains("H"))
                {
                    char_restrict_3 = "B";
                }
                else
                {
                    char_delete_3 = "B";
                }
            }

            env_reduced.Clear();

            // reducing prefab list to prefab containing D entrance
            foreach (GameObject env in env_prefabs)
            {
                    if (env.name.Contains("D") && env.name.Contains(char_restrict_1) && env.name.Contains(char_restrict_2) && env.name.Contains(char_restrict_3) && !env.name.Contains(char_delete_1) && !env.name.Contains(char_delete_2) && !env.name.Contains(char_delete_3))
                    {
                        env_reduced.Add(env);
                    }
            }
            if (env_reduced.Count == 0) // si on n'a plus de troncon normal, on selectionne un bouchon
            {
                foreach (GameObject env in closing_prefabs)
                {
                    if (env.name.Contains("D") && env.name.Contains(char_restrict_1) && env.name.Contains(char_restrict_2) && env.name.Contains(char_restrict_3) && !env.name.Contains(char_delete_1) && !env.name.Contains(char_delete_2) && !env.name.Contains(char_delete_3))
                    {
                        env_reduced.Add(env);
                    }
                }
            }


            new_env.plane = env_reduced[Random.Range(0, env_reduced.Count)];


            //----------------------------------------- set bools -----------------------------------------//
            if (new_env.plane.name.Contains("G"))
                new_env.G = true;
            else
                new_env.G = false;

            if (new_env.plane.name.Contains("H"))
                new_env.H = true;
            else
                new_env.H = false;

            if (new_env.plane.name.Contains("D"))
                new_env.D = true;
            else
                new_env.D = false;

            if (new_env.plane.name.Contains("B"))
                new_env.B = true;
            else
                new_env.B = false;
            //------------------------------------------------------------------------------------------//

            new_env.ID = ID_count;
            ID_count++;

            Instantiate(new_env.plane, new_env.coord, Quaternion.Euler(0, 180, 0));
            envs.Add(new_env);
        }
        // -------------------------------------------------------------------------------------------------------------------------//








        // -------------------------------------- création de l'env à droite de la case appelante ---------------------------------------//
        if (current_env.D && !already_D) // si une ouverture à droite
        {
            string str_prox_G = "", str_prox_H = "", str_prox_D = "", str_prox_B = "";
            string char_restrict_1 = "", char_restrict_2 = "", char_restrict_3 = "", char_delete_1 = "FFFFFF", char_delete_2 = "FFFFFF", char_delete_3 = "FFFFFF";

            env new_env = new env();
            new_env.coord = current_env.coord;
            new_env.coord.x += 10;

            // set proxi bools
            new_env.prox_G = true;
            new_env.prox_H = false;
            new_env.prox_D = false;
            new_env.prox_B = false;

            foreach (env env_created in envs) // on vérifie les cases en croix autour de la case que l'on va rajouter à gauche
            {
                if (env_created.coord.x == new_env.coord.x - 10 && env_created.coord.z == new_env.coord.z) // check if env déjà présent à gauche 
                {
                    str_prox_G = env_created.plane.name;
                    new_env.prox_G = true;
                }
                if (env_created.coord.x == new_env.coord.x + 10 && env_created.coord.z == new_env.coord.z) // check if env déjà présent à droite 
                {
                    str_prox_D = env_created.plane.name;
                    new_env.prox_D = true;
                }
                if (env_created.coord.x == new_env.coord.x && env_created.coord.z == new_env.coord.z - 10) // check if env déjà présent en bas 
                {
                    str_prox_B = env_created.plane.name;
                    new_env.prox_B = true;
                }
                if (env_created.coord.x == new_env.coord.x && env_created.coord.z == new_env.coord.z + 10) // check if env déjà présent en haut 
                {
                    str_prox_H = env_created.plane.name;
                    new_env.prox_H = true;
                }
            }


            if (new_env.prox_D) // une case existe à droite de là où on veut créer // should use new_env_X 
            {
                if (str_prox_D.Contains("G"))
                {
                    char_restrict_1 = "D";
                }
                else
                {
                    char_delete_1 = "D";
                }
            }

            if (new_env.prox_H) // une case existe en haut de là où on veut créer
            {
                if (str_prox_H.Contains("B"))
                {
                    char_restrict_2 = "H";
                }
                else
                {
                    char_delete_2 = "H";
                }
            }

            if (new_env.prox_B) // une case existe en bas de là où on veut créer
            {
                if (str_prox_B.Contains("H"))
                {
                    char_restrict_3 = "B";
                }
                else
                {
                    char_delete_3 = "B";
                }
            }

            env_reduced.Clear();
            // reducing prefab list to prefab containing D entrance
            foreach (GameObject env in env_prefabs)
            {
                if (env.name.Contains("G") && env.name.Contains(char_restrict_1) && env.name.Contains(char_restrict_2) && env.name.Contains(char_restrict_3) && !env.name.Contains(char_delete_1) && !env.name.Contains(char_delete_2) && !env.name.Contains(char_delete_3))
                {
                    env_reduced.Add(env);
                }
            }
            if (env_reduced.Count == 0) // si on n'a plus de troncon normal, on selectionne un bouchon
            {
                foreach (GameObject env in closing_prefabs)
                {
                    if (env.name.Contains("G") && env.name.Contains(char_restrict_1) && env.name.Contains(char_restrict_2) && env.name.Contains(char_restrict_3) && !env.name.Contains(char_delete_1) && !env.name.Contains(char_delete_2) && !env.name.Contains(char_delete_3))
                    {
                        env_reduced.Add(env);
                    }
                }
            }

            new_env.plane = env_reduced[Random.Range(0, env_reduced.Count)];



            //----------------------------------------- set bools -----------------------------------------//
            if (new_env.plane.name.Contains("G"))
                new_env.G = true;
            else
                new_env.G = false;

            if (new_env.plane.name.Contains("H"))
                new_env.H = true;
            else
                new_env.H = false;

            if (new_env.plane.name.Contains("D"))
                new_env.D = true;
            else
                new_env.D = false;

            if (new_env.plane.name.Contains("B"))
                new_env.B = true;
            else
                new_env.B = false;
            //------------------------------------------------------------------------------------------//

            new_env.ID = ID_count;
            ID_count++;

            Instantiate(new_env.plane, new_env.coord, Quaternion.Euler(0, 180, 0));
            envs.Add(new_env);
        }
        // -------------------------------------------------------------------------------------------------------------------------//





        // -------------------------------------- création de l'env en haut de la case appelante ---------------------------------------//
        if (current_env.H && !already_H) // si une ouverture en haut
        {
            string str_prox_G = "", str_prox_H = "", str_prox_D = "", str_prox_B = "";
            string char_restrict_1 = "", char_restrict_2 = "", char_restrict_3 = "", char_delete_1 = "FFFFFF", char_delete_2 = "FFFFFF", char_delete_3 = "FFFFFF";

            env new_env = new env();
            new_env.coord = current_env.coord;
            new_env.coord.z += 10;

            // set proxi bools
            new_env.prox_G = false;
            new_env.prox_H = false;
            new_env.prox_D = false;
            new_env.prox_B = true;

            foreach (env env_created in envs) // on vérifie les cases en croix autour de la case que l'on va rajouter à gauche
            {
                if (env_created.coord.x == new_env.coord.x - 10 && env_created.coord.z == new_env.coord.z) // check if env déjà présent à gauche 
                {
                    str_prox_G = env_created.plane.name;
                    new_env.prox_G = true;
                }
                if (env_created.coord.x == new_env.coord.x + 10 && env_created.coord.z == new_env.coord.z) // check if env déjà présent à droite 
                {
                    str_prox_D = env_created.plane.name;
                    new_env.prox_D = true;
                }
                if (env_created.coord.x == new_env.coord.x && env_created.coord.z == new_env.coord.z - 10) // check if env déjà présent en bas 
                {
                    str_prox_B = env_created.plane.name;
                    new_env.prox_B = true;
                }
                if (env_created.coord.x == new_env.coord.x && env_created.coord.z == new_env.coord.z + 10) // check if env déjà présent en haut 
                {
                    str_prox_H = env_created.plane.name;
                    new_env.prox_H = true;
                }
            }


            if (new_env.prox_G) // une case existe à gauche de là où on veut créer // should use new_env_X 
            {
                if (str_prox_G.Contains("D"))
                {
                    char_restrict_1 = "G";
                }
                else
                {
                    char_delete_1 = "G";
                }
            }

            if (new_env.prox_H) // une case existe en haut de là où on veut créer
            {
                if (str_prox_H.Contains("B"))
                {
                    char_restrict_2 = "H";
                }
                else
                {
                    char_delete_2 = "H";
                }
            }

            if (new_env.prox_D) // une case existe à droite de là où on veut créer
            {
                if (str_prox_D.Contains("G"))
                {
                    char_restrict_3 = "D";
                }
                else
                {
                    char_delete_3 = "D";
                }
            }



            env_reduced.Clear();
            // reducing prefab list to prefab containing D entrance
            foreach (GameObject env in env_prefabs)
            {
                if (env.name.Contains("B") && env.name.Contains(char_restrict_1) && env.name.Contains(char_restrict_2) && env.name.Contains(char_restrict_3) && !env.name.Contains(char_delete_1) && !env.name.Contains(char_delete_2) && !env.name.Contains(char_delete_3))
                {
                    env_reduced.Add(env);
                }
            }
            if (env_reduced.Count == 0) // si on n'a plus de troncon normal, on selectionne un bouchon
            {
                foreach (GameObject env in closing_prefabs)
                {
                    if (env.name.Contains("B") && env.name.Contains(char_restrict_1) && env.name.Contains(char_restrict_2) && env.name.Contains(char_restrict_3) && !env.name.Contains(char_delete_1) && !env.name.Contains(char_delete_2) && !env.name.Contains(char_delete_3))
                    {
                        env_reduced.Add(env);
                    }
                }
            }

            new_env.plane = env_reduced[Random.Range(0, env_reduced.Count)];


            //----------------------------------------- set bools -----------------------------------------//
            if (new_env.plane.name.Contains("G"))
                new_env.G = true;
            else
                new_env.G = false;

            if (new_env.plane.name.Contains("H"))
                new_env.H = true;
            else
                new_env.H = false;

            if (new_env.plane.name.Contains("D"))
                new_env.D = true;
            else
                new_env.D = false;

            if (new_env.plane.name.Contains("B"))
                new_env.B = true;
            else
                new_env.B = false;
            //------------------------------------------------------------------------------------------//

            new_env.ID = ID_count;
            ID_count++;

            Instantiate(new_env.plane, new_env.coord, Quaternion.Euler(0, 180, 0));
            envs.Add(new_env);
        }
        // -------------------------------------------------------------------------------------------------------------------------//





        // -------------------------------------- création de l'env en bas de la case appelante ---------------------------------------//
        if (current_env.B && !already_B) // si une ouverture en haut
        {
            string str_prox_G = "", str_prox_H = "", str_prox_D = "", str_prox_B = "";
            string char_restrict_1 = "", char_restrict_2 = "", char_restrict_3 = "", char_delete_1 = "FFFFFF", char_delete_2 = "FFFFFF", char_delete_3 = "FFFFFF";


            env new_env = new env();
            new_env.coord = current_env.coord;
            new_env.coord.z -= 10;

            // set proxi bools
            new_env.prox_G = false;
            new_env.prox_H = true;
            new_env.prox_D = false;
            new_env.prox_B = false;

            foreach (env env_created in envs) // on vérifie les cases en croix autour de la case que l'on va rajouter à gauche
            {
                if (env_created.coord.x == new_env.coord.x - 10 && env_created.coord.z == new_env.coord.z) // check if env déjà présent à gauche 
                {
                    str_prox_G = env_created.plane.name;
                    new_env.prox_G = true;
                }
                if (env_created.coord.x == new_env.coord.x + 10 && env_created.coord.z == new_env.coord.z) // check if env déjà présent à droite 
                {
                    str_prox_D = env_created.plane.name;
                    new_env.prox_D = true;
                }
                if (env_created.coord.x == new_env.coord.x && env_created.coord.z == new_env.coord.z - 10) // check if env déjà présent en bas 
                {
                    str_prox_B = env_created.plane.name;
                    new_env.prox_B = true;
                }
                if (env_created.coord.x == new_env.coord.x && env_created.coord.z == new_env.coord.z + 10) // check if env déjà présent en haut 
                {
                    str_prox_H = env_created.plane.name;
                    new_env.prox_H = true;
                }
            }


            if (new_env.prox_G) // une case existe à gauche de là où on veut créer // should use new_env_X 
            {
                if (str_prox_G.Contains("D"))
                {
                    char_restrict_1 = "G";
                }
                else
                {
                    char_delete_1 = "G";
                }
            }

            if (new_env.prox_D) // une case existe à droite de là où on veut créer
            {
                if (str_prox_D.Contains("G"))
                {
                    char_restrict_2 = "D";
                }
                else
                {
                    char_delete_2 = "D";
                }
            }

            if (new_env.prox_B) // une case existe en bas de là où on veut créer
            {
                if (str_prox_B.Contains("H"))
                {
                    char_restrict_3 = "B";
                }
                else
                {
                    char_delete_3 = "B";
                }
            }


            env_reduced.Clear();
            // reducing prefab list to prefab containing D entrance
            foreach (GameObject env in env_prefabs)
            {
                if (env.name.Contains("H") && env.name.Contains(char_restrict_1) && env.name.Contains(char_restrict_2) && env.name.Contains(char_restrict_3) && !env.name.Contains(char_delete_1) && !env.name.Contains(char_delete_2) && !env.name.Contains(char_delete_3))
                {
                    env_reduced.Add(env);
                }
            }
            if (env_reduced.Count == 0) // si on n'a plus de troncon normal, on selectionne un bouchon
            {
                foreach (GameObject env in closing_prefabs)
                {
                    if (env.name.Contains("H") && env.name.Contains(char_restrict_1) && env.name.Contains(char_restrict_2) && env.name.Contains(char_restrict_3) && !env.name.Contains(char_delete_1) && !env.name.Contains(char_delete_2) && !env.name.Contains(char_delete_3))
                    {
                        env_reduced.Add(env);
                    }
                }
            }

            new_env.plane = env_reduced[Random.Range(0, env_reduced.Count)];

            //----------------------------------------- set bools -----------------------------------------//
            if (new_env.plane.name.Contains("G"))
                new_env.G = true;
            else
                new_env.G = false;

            if (new_env.plane.name.Contains("H"))
                new_env.H = true;
            else
                new_env.H = false;

            if (new_env.plane.name.Contains("D"))
                new_env.D = true;
            else
                new_env.D = false;

            if (new_env.plane.name.Contains("B"))
                new_env.B = true;
            else
                new_env.B = false;
            //------------------------------------------------------------------------------------------//

            new_env.ID = ID_count;
            ID_count++;

            Instantiate(new_env.plane, new_env.coord, Quaternion.Euler(0, 180, 0));
            envs.Add(new_env);
        }
        // -------------------------------------------------------------------------------------------------------------------------//
    }
    
}
