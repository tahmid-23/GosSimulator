using System.Collections.Generic;
using JetBrains.Annotations;
using ProjectilesFolder;
using UnityEngine;

namespace PranjalCombat
{
    public abstract class Range: Weapon
    {
        private double _bloomRange;
        private double _focusSpeed;
        
        // I'm storing a list just for all of the attacks just in case we ever want to make it such that a player
        // can have more attacks than just one
        private List<Attack> _standardAttackList = new List<Attack>();
        private List<Attack> _specialAttackList = new List<Attack>();

        private Attack _standardAttack;
        private Attack _specialAttack;

        private GameObject _projectilePrefab;

        protected Range()
        {
            
        }

        protected Range(double bloomRange, double focusSpeed, Attack standardAttack, Attack specialAttack)
        {
            this._bloomRange = bloomRange;
            this._focusSpeed = focusSpeed;
            this._standardAttack = standardAttack;
            this._specialAttack = specialAttack;

            _standardAttackList.Add(_standardAttack);
            _specialAttackList.Add(_specialAttack);
        }

        public GameObject GetProjectilePrefab()
        {
            Debug.Log(_projectilePrefab);
            return _projectilePrefab;
        }

        public void SetProjectilePrefab(GameObject projectilePrefab)
        {
            Debug.Log("Set to " + projectilePrefab);
            this._projectilePrefab = projectilePrefab;
        }
    }
}