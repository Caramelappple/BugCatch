using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NKY.Script.BugUnits
{
    public abstract class AbstractBugUnit : MonoBehaviour
    {
        
        [SerializeField, Min(5f)] private float secTurnAngle = 60;
        [SerializeField] private float raycastDistance;
        [SerializeField] private LayerMask wallLayerMask;
        public Rigidbody2D Rb {get; private set;}
        public SpriteRenderer Sr {get; private set;}

        private BugUnitMoveSo _bugData;
        
        private float _turnDelay;
        private float _boundDelay;

        public void Init(BugUnitMoveSo bugData)
        {
            _bugData = bugData;
            Rb.linearVelocity = transform.up * _bugData.moveSpeed;
            Sr.sprite = _bugData.bugSprite;
        }

        protected virtual void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            Sr = GetComponent<SpriteRenderer>();
        }

        protected virtual void Update()
        {
            if(_bugData == null) return;
            MovementCheck();
            TurnReflectCheck();
        }

        #region BugMovement

        private void MovementCheck()
        {
            _turnDelay += Time.deltaTime;
            if (_turnDelay >= _bugData.turnDelay)
            {
                _turnDelay = 0;
                BugMovement();
            }
            Rb.linearVelocity = transform.up * _bugData.moveSpeed;
        }

        private void BugMovement()
        {
            float angle = Random.Range(-_bugData.turnAngle, _bugData.turnAngle); // 회전 각도를 구한다
            float turnTime = Mathf.Abs(angle) / secTurnAngle; // 초당 n도 돌아가도록 시간계산
            _turnDelay -= turnTime; // 회전 하는 시간은 제외하고 딜레이 계산
            Sequence s = DOTween.Sequence();
            
            s.Append(transform.DOBlendableLocalRotateBy(new Vector3(0, 0, angle), turnTime, RotateMode.FastBeyond360)); // 회전시키고
        }

        #endregion

        #region TurnBug

        private void TurnReflectCheck()
        {
            RaycastHit2D hitWall = Physics2D.Raycast(transform.position, transform.up, raycastDistance, wallLayerMask);
            if(hitWall.collider == null) return;
            TurnReflect(hitWall.normal);
        }
        
        private void TurnReflect(Vector2 normal)
        {
            float reflectAngle = Random.Range(-_bugData.reflectAngle, _bugData.reflectAngle);
            Vector3 direction = new Vector3(Mathf.Cos(reflectAngle), Mathf.Sin(reflectAngle)).normalized;
            
            transform.up = Vector3.Reflect(transform.up + direction, normal);
            Rb.linearVelocity = transform.up * _bugData.moveSpeed;
        }

        #endregion

        private void OnCollisionStay2D(Collision2D other)
        {
            _boundDelay += Time.deltaTime;
            if (_boundDelay >= 0.7f)
            {
                _boundDelay = 0;
                Vector3 dir = other.contacts[0].normal;
                TurnReflect(dir);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _boundDelay = 0;
        }
    }
}
