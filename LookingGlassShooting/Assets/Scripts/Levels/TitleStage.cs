using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStage : MonoBehaviour
{
    private SceneController _sceneController;
    private bool _inTransition = false;
    void Start()
    {
        _sceneController = GetComponent<SceneController>();
    }

    void Update()
    {
        if (Input.anyKey && !_inTransition)
        {
            _inTransition = true;
            GoCharacterSelect();
        }
    }

    private void GoCharacterSelect()
    {
        if (_sceneController != null)
        {
            _sceneController.ShowCharacterSelect();
        }
    }
}
