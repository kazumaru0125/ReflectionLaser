using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �X�e�[�W�I����ʂł̃{�^���Ǘ��N���X
/// </summary>
public class SelectButtonManager : MonoBehaviour
{
    /// <summary>
    /// �{�^���������ꂽ�ۂɌĂяo����郁�\�b�h
    /// </summary>
    /// <param name="button">�{�^�����ʗp�̕�����i�{�^�����j</param>
    /// <remarks>
    /// Unity�G�f�B�^�̃{�^���C�x���g�ݒ�ł��̃��\�b�h���Ăяo���܂��B
    /// �����ɂ́A"Title" �� "Stage1" �Ȃǂ̕�������w�肵�Ă��������B
    /// </remarks>
    public void TappedButton(string button)
    {
        // �{�^�����ɂ���ď����𕪊�
        switch (button)
        {
            case "Title":
                // �^�C�g���{�^���������ꂽ�ꍇ�̏���
                Debug.Log("�^�C�g���{�^����������܂���");

                // �^�C�g���V�[���֑J��
                // ����: "TitleScene" �̓r���h�ݒ�ɓo�^����Ă���K�v������܂��B
                SceneManager.LoadScene("TitleScene");
                break;

            case "Stage1":
                // �X�e�[�W1�{�^���������ꂽ�ꍇ�̏���
                Debug.Log("�X�e�[�W1�{�^����������܂���");

                // �X�e�[�W1�̃V�[���֑J��
                // ����: "SampleScene" �̓r���h�ݒ�ɓo�^����Ă���K�v������܂��B
                SceneManager.LoadScene("SampleScene");
                break;

            case "Stage2":
                // �X�e�[�W2�{�^���������ꂽ�ꍇ�̏���
                Debug.Log("�X�e�[�W2�{�^����������܂���");

                // �X�e�[�W2�̃V�[���֑J�ځi�������j
                // TODO: �X�e�[�W2�p�̃V�[������ݒ肵�Ă��������B
                // SceneManager.LoadScene("");
                break;

            case "Stage3":
                // �X�e�[�W3�{�^���������ꂽ�ꍇ�̏���
                Debug.Log("�X�e�[�W3�{�^����������܂���");

                // �X�e�[�W3�̃V�[���֑J�ځi�������j
                // TODO: �X�e�[�W3�p�̃V�[������ݒ肵�Ă��������B
                // SceneManager.LoadScene("");
                break;

            default:
                // ����`�̃{�^���������ꂽ�ꍇ�̌x�����O
                Debug.LogWarning($"�s���ȃ{�^��: {button}");

                // �G�f�B�^��Ń{�^���ݒ���ԈႦ���ꍇ��A�^�C�|�ɂ��G���[���ɔ������܂��B
                break;
        }
    }
}
