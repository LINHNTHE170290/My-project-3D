using Invector.vCharacterController;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool m_gameover; // Trạng thái game over
    GameoverUIManager m_ui;
    Timer m_timer;
    vThirdPersonInput m_playerInput; // Thêm biến cho input controller
    vThirdPersonController m_playerController; // Thêm biến cho controller
    vThirdPersonAnimator vThirdPersonAnimator;
    // Danh sách các bẫy
    FireTrap[] fireTraps;
    MoveByPoints m_moveByPoints;
    MovingTrap[] movingTraps;
    RotatingTrap[] rotatingTraps;
    SawTrap[] sawTraps;
    SpikeTrap[] spikeTraps;
    SwingingHammerTrap[] swingHammerTraps;
    TiltingTrap[] tiltingHammerTraps;

    void Start()
    {
        m_ui = FindAnyObjectByType<GameoverUIManager>();
        m_timer = FindObjectOfType<Timer>();
        m_playerInput = FindObjectOfType<vThirdPersonInput>(); // Khởi tạo input controller
        m_playerController = FindObjectOfType<vThirdPersonController>(); // Khởi tạo controller
        vThirdPersonAnimator = FindObjectOfType<vThirdPersonAnimator>();
        // Khởi tạo danh sách các bẫy
        fireTraps = FindObjectsOfType<FireTrap>();
        m_moveByPoints = FindObjectOfType<MoveByPoints>();
        movingTraps = FindObjectsOfType<MovingTrap>();
        rotatingTraps = FindObjectsOfType<RotatingTrap>();
        sawTraps = FindObjectsOfType<SawTrap>();
        spikeTraps = FindObjectsOfType<SpikeTrap>();
        swingHammerTraps = FindObjectsOfType<SwingingHammerTrap>();
        tiltingHammerTraps = FindObjectsOfType<TiltingTrap>();
    }

    void Update()
    {
        // Nếu trò chơi đã kết thúc thì dừng xử lý
        if (m_gameover)
        {
            m_ui.ShowGameoverPanel(true); // Hiển thị giao diện kết thúc trò chơi
            StopAllActivities(); // Dừng tất cả hoạt động
            return;
        }
    }

    void StopAllActivities()
    {
        // Dừng bộ đếm thời gian
        if (m_timer != null)
        {
            m_timer.StopTimer();
        }

        // Vô hiệu hóa điều khiển người chơi
        if (m_playerInput != null)
        {
            m_playerInput.enabled = false; // Vô hiệu hóa input controller
        }

        if (m_playerController != null)
        {
            m_playerController.enabled = false; // Vô hiệu hóa controller
        }
        if (vThirdPersonAnimator!= null)
        {
           vThirdPersonAnimator.enabled = false; // Vô hiệu hóa controller
        }

        // Dừng tất cả các bẫy
        foreach (var trap in fireTraps)
        {
            trap.enabled = false; // Dừng bẫy lửa
        }
        if (m_moveByPoints != null)
        {
            m_moveByPoints.enabled = false; // Dừng di chuyển theo điểm
        }
        foreach (var trap in movingTraps)
        {
            trap.enabled = false; // Dừng bẫy di chuyển
        }
        foreach (var trap in rotatingTraps)
        {
            trap.enabled = false; // Dừng bẫy xoay
        }
        foreach (var trap in sawTraps)
        {
            trap.enabled = false; // Dừng bẫy cưa
        }
        foreach (var trap in spikeTraps)
        {
            trap.enabled = false; // Dừng bẫy gai
        }
        foreach (var trap in swingHammerTraps)
        {
            trap.enabled = false; // Dừng bẫy búa đu đưa
        }
        foreach (var trap in tiltingHammerTraps)
        {
            trap.enabled = false; // Dừng bẫy nghiêng
        }
    }

    // Hàm để chơi lại game
    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SetGameoverState(bool state)
    {
        m_gameover = state;
    }

    public bool Gameover()
    {
        return m_gameover;
    }
}
