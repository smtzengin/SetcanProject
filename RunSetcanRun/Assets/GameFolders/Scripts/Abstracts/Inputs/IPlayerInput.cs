using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Abstracts.Inputs
{
    public interface IPlayerInput
    {
        float Horizontal { get; }
        float Vertical { get; }

        bool isJumpButtonDown { get; }
    }
}
