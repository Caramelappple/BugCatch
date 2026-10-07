using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NKY.Script.BugUnits
{
    public class BugUnitSpawner : MonoBehaviour
    {
        [SerializeField] private List<BugUnitMoveSo> bugDates;
        [SerializeField] private BugUnit bugUnitPrefab;
        [SerializeField] private Collider2D spawnRange;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SpawnBugs();
            }
        }

        private void SpawnBugs()
        {
            BugUnit bugUnit = Instantiate(bugUnitPrefab, transform);
            BugUnitMoveSo bugDate = bugDates[Random.Range(0, bugDates.Count)];
            
            Vector2 spawnPosition = GetSpawnPosition();
            Vector3 scale = bugUnit.transform.localScale;
            
            bugUnit.transform.position = spawnPosition;
            bugUnit.transform.localScale = Vector3.zero;
            
            Color color = bugUnit.Sr.color;
            color.a = 0;
            bugUnit.Sr.color = color;
            
            Sequence seq = DOTween.Sequence();
            seq.Append(bugUnit.transform.DOScale(scale, 0.7f));
            seq.Join(bugUnit.Sr.DOFade(1, 0.7f));
            seq.JoinCallback(() => bugUnit.Init(bugDate));
        }

        private Vector2 GetSpawnPosition()
        {
            float spawnX = Random.Range(spawnRange.bounds.min.x + 1, spawnRange.bounds.max.x - 1);
            float spawnY = Random.Range(spawnRange.bounds.min.y + 1, spawnRange.bounds.max.y - 1);
            return new Vector2(spawnX, spawnY);
        }
    }
}