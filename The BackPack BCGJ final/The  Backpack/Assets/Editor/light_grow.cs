using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEditor;
using UnityEngine.SceneManagement;

public class light_grow : MonoBehaviour
{
    public Animator transition; 
    public float transitionTime = 1f; 
    [SerializeField] private float _size;

    // Start is called before the first frame update
    void Start()
    {
        _size = 2; 
    }

    // Update is called once per frame
    void Update()
    {
        if (_size < 1) {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        }
    } 

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start"); 
        yield return new WaitForSeconds(transitionTime); 
        SceneManager.LoadScene(levelIndex);
    }   

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag.Equals("Light")) {
            SerializedObject halo = new SerializedObject(GetComponent("Halo"));
            if (_size <= 7) {
                _size = _size + (float) 0.5;
            }
            halo.FindProperty("m_Size").floatValue = _size;
            halo.ApplyModifiedProperties(); 
        } 
        if (col.gameObject.tag.Equals("Dark")) {
            SerializedObject halo = new SerializedObject(GetComponent("Halo"));
            if (_size >= 1) {
                _size = _size - (float) 0.5; 
            } 
            halo.FindProperty("m_Size").floatValue = _size; 
            halo.ApplyModifiedProperties();       
        }
    }
}
