using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager instance;

    public TextMeshProUGUI nameText;

    public string characterName;

    public TextMeshProUGUI dialogueText;

    public AudioSource audioPlayer;
    public AudioSource audioPlayer1;
    public AudioSource audioPlayer2;
    public AudioSource audioPlayer3;



    [SerializeField] GameObject Next;
    [SerializeField] GameObject Continue;
    //keeps track of descendants 
    private Queue<string> sentences; //FIFO - better format for dialogue

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting convo with " + dialogue.name);
        characterName = dialogue.name;
        nameText.text = dialogue.name;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            
            sentences.Enqueue(sentence);
        }
        
        

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        
            if (sentences.Count == 0)
            {
                EndDialogue();

                Next.SetActive(true);
                Continue.SetActive(false);
                return;
            }
            if(characterName == "Dahlia"){
                audioPlayer.Play();
            }
            if(characterName == "You"){
                audioPlayer1.Play();
            }
            if(characterName == "Salem"){
                audioPlayer2.Play();
            }
            if(characterName == "Edmund"){
                audioPlayer3.Play();
            }


        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        

        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        //dialogueText.text = sentence;

        dialogueText.text = sentence;
       
        
        //Debug.Log(sentences.Count);


    }

    public void DahliaVoice(){
        audioPlayer.Stop();
        
        

    }
    public void PlayerVoice(){
        audioPlayer1.Stop();
    }

    public void SalemVoice(){
        audioPlayer2.Stop();
    }

    public void EdmundVoice(){
        audioPlayer3.Stop();
    }



    void EndDialogue()
    {
        //Debug.Log("End convo");
    }

    IEnumerator Wait(){
        Debug.Log("Waiting");
        yield return new WaitForSeconds(3f);
        audioPlayer.Play();
   
    }

    IEnumerator WaitLonger(){
        Debug.Log("Waiting");
        yield return new WaitForSeconds(3f);
        audioPlayer1.Play();
        yield return new WaitForSeconds(3f);
        Debug.Log("Waited");
    }

}
