using System.Collections;
using UnityEngine;

public class Pattern_EyeBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImage; // ��� �̹���
    [SerializeField]
    private GameObject ground; // �߰� �� ����
    [SerializeField]
    private GameObject eyeboss; // ������
    [SerializeField]
    private GameObject laser; // ������ �� ��ġ ������
    [SerializeField]
    private Collider2D[] laserCollider2D; // �������� �浹 ���� Collider2D
    [SerializeField]
    private float rotateTime; // ȸ�� �ð�
    [SerializeField]
    private int anglePerSeconds; // �ʴ� ȸ�� ����

    public AudioSource cleareye; // ������ ���� ����
    public AudioSource lasersound; // ������ ȿ����

    [SerializeField]
    private GameObject[] ps;

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(Process));
    }


    private IEnumerator Process()
    {

        // ��� �̹��� 0.5�� ���� Ȱ�� �� ��Ȱ��ȭ
        for (int i = 0; i < 2; i++)  warningImage[i].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        for (int i=0; i<2; i++)  warningImage[i].SetActive(false);

        yield return new WaitForSeconds(1);

        // ����, ������, ������ Ȱ��ȭ
        ground.SetActive(true);
        eyeboss.SetActive(true);
        laser.SetActive(true);

        for (int i=0; i<ps.Length; i++)
        {
            ps[i].SetActive(true);
        }

        cleareye.Play();
        lasersound.Play();

        // �������� �������ڸ��� �÷��̾�� �浹���� �ʵ��� Collider2D�� ��� ��Ȱ��ȭ
        for (int i = 0; i < laserCollider2D.Length; ++i)
        {
            laserCollider2D[i].enabled = false;
        }

        // �������� �����ϰ� ��� ����ϴ� �ð�
        yield return new WaitForSeconds(0.5f);

        // �������� Collider2D Ȱ��ȭ
        for (int i = 0; i < laserCollider2D.Length; ++i)
        {
            laserCollider2D[i].enabled = true;
        }

        // ������ ȸ�� (�ð�)
        float time = 0;
        while (time < rotateTime)
        {
            laser.transform.Rotate(Vector3.forward * anglePerSeconds * Time.deltaTime);

            time += Time.deltaTime;

            yield return null;
        }

        time = 0;

        while (time < rotateTime)
        {
            laser.transform.Rotate(Vector3.back * anglePerSeconds * Time.deltaTime);

            time += Time.deltaTime;

            yield return null;
        }

        // ���� �� ������, ������, ���� ��Ȱ��ȭ
        cleareye.Stop();
        ground.SetActive(false);
        eyeboss.SetActive(false);
        laser.SetActive(false);
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].SetActive(false);
        }


        // ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
