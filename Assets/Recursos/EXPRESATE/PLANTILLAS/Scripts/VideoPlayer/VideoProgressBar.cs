using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Recursos.EXPRESATE.PLANTILLAS.Scripts.VideoPlayer
{
    public class VideoProgressBar : MonoBehaviour, IDragHandler, IPointerDownHandler
    {
        [SerializeField] private UnityEngine.Video.VideoPlayer videoPlayer;

        private Image _progress;

        private void Awake() {
            _progress = GetComponent<Image>();
        }

        private void Update() {
            if (videoPlayer.frameCount > 0)
                _progress.fillAmount = (float) videoPlayer.frame / (float) videoPlayer.frameCount;
        }

        public void OnDrag(PointerEventData eventData) {
            TrySkip(eventData);
        }

        public void OnPointerDown(PointerEventData eventData) {
            TrySkip(eventData);
        }

        private void TrySkip(PointerEventData eventData) {
            Vector2 localPoint;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _progress.rectTransform, eventData.position, null, out localPoint)) {
                float pct = Mathf.InverseLerp(_progress.rectTransform.rect.xMin, _progress.rectTransform.rect.xMax,
                    localPoint.x);
                SkipToPercent(pct);
            }
        }

        private void SkipToPercent(float pct) {
            var frame = videoPlayer.frameCount * pct;
            videoPlayer.frame = (long) frame;
        }

        public void RestartVideo() {
            videoPlayer.frame = 0;
            videoPlayer.Play();
        }
    }
}