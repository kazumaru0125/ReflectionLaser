using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���U���g��ʗp�̃{�^���Ǘ��N���X
/// </summary>
public class ResultButtonManager : MonoBehaviour
{
    // �O�̃V�[������ۑ�����ÓI�ϐ��i�V�[���Ԃł��l���ێ������j
    // static�C���q�����邱�ƂŃN���X���x���Œl��ێ�
    private static string previousScene = "";

    /// <summary>
    /// ���݂̃V�[�������L�^����ÓI���\�b�h
    /// </summary>
    /// <remarks>
    /// �V�[���J�ڑO�ɌĂяo���Č��݂̃V�[������ۑ����܂�
    /// ��: �Q�[���I�[�o�[���ɌĂяo���ă��g���C�\�ȃV�[�����L�^
    /// </remarks>
    public static void RecordCurrentScene()
    {
        // ���݃A�N�e�B�u�ȃV�[���̖��O���擾
        previousScene = SceneManager.GetActiveScene().name;

        // �f�o�b�O�p���O�i�K�v�ɉ����ăR�����g�A�E�g�����j
        // Debug.Log($"�V�[���L�^: {previousScene}");
    }

    /// <summary>
    /// �{�^���^�b�v���̏������\�b�h
    /// </summary>
    /// <param name="button">�{�^�����ʗp������</param>
    /// <remarks>
    /// Unity�G�f�B�^�̃{�^���C�x���g�ݒ�ŕ�����������w�肵�ČĂяo���܂�
    /// ��: �{�^���I�u�W�F�N�g��OnClick�C�x���g�ɂ��̃��\�b�h��ݒ肵�A
    ///     ������"TitleButton"�܂���"RetryButton"���w��
    /// </remarks>
    public void TappedButton(string button)
    {
        // �{�^����ʂŏ����𕪊�
        switch (button)
        {
            // �^�C�g���{�^���������ꂽ�ꍇ
            case "TitleButton":
                Debug.Log("�^�C�g����ʂ֑J�ڂ��܂�");

                // �^�C�g���V�[�������[�h
                // ����: "TitleScene"�̓r���h�ݒ�ɓo�^����Ă���K�v������܂�
                SceneManager.LoadScene("TitleScene");
                break;

            // ���g���C�{�^���������ꂽ�ꍇ
            case "RetryButton":
                Debug.Log("���g���C�����݂܂�");

                // �O�V�[�������L�����`�F�b�N
                if (!string.IsNullOrEmpty(previousScene))
                {
                    // �L�^����Ă���O�̃V�[�����ă��[�h
                    Debug.Log($"�O�V�[���ēǂݍ���: {previousScene}");
                    SceneManager.LoadScene(previousScene);
                }
                else
                {
                    // �L�^���Ȃ��ꍇ�̃t�H�[���o�b�N����
                    Debug.LogWarning("�O�V�[���̋L�^������܂���");

                    // �^�C�g���V�[���Ƀt�H�[���o�b�N
                    // ����: �Q�[���J�n����Ȃǂ�previousScene����̏ꍇ�ɔ���
                    SceneManager.LoadScene("TitleScene");
                }
                break;

            // ����`�̃{�^�����w�肳�ꂽ�ꍇ
            default:
                // �s���Ȉ����̌x�����O
                Debug.LogWarning($"�s���ȃ{�^���w��: {button}");

                // �G�f�B�^��Ń{�^���ݒ���ԈႦ���ꍇ�ɔ���
                // ��: �����̃^�C�|�i"RetryButton" �� "RertyButton"�Ȃǁj
                break;
        }
    }
}
