﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.MixedReality.Toolkit.Core.Definitions.Utilities;
using Microsoft.MixedReality.Toolkit.Core.Interfaces.Events;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Core.Interfaces.SpatialAwarenessSystem.Observers
{
    public interface IMixedRealitySpatialAwarenessObserver : IMixedRealityDataProvider, IMixedRealityEventSource
    {
        /// <summary>
        /// Indicates the developer's intended startup behavior.
        /// </summary>
        AutoStartBehavior StartupBehavior { get; set; }

        /// <summary>
        /// Get or sets the default Unity Physics Layer on which to set the spatial object.
        /// </summary>
        int DefaultPhysicsLayer { get; set; }

        /// <summary>
        /// Gets the bit mask that corresponds to the value specified in <see cref="DefaultPhysicsLayer"/>.
        /// </summary>
        int DefaultPhysicsLayerMask { get; }

        /// <summary>
        /// Is the observer running (actively accumulating spatial data)?
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Should the observer remain stationary in the scene?
        /// </summary>
        /// <remarks>
        /// Set IsStationaryObserver to false to move the volume with the user. 
        /// If set to true, the origin will be 0,0,0 or the last known location.
        /// </remarks>
        bool IsStationaryObserver { get; set; }

        /// <summary>
        /// Gets or sets the type of volume the observer should operate in.
        /// </summary>
        VolumeType ObserverVolumeType { get; set; }

        /// <summary>
        /// Gets or sets the extents( 1/2 size) of the volume, in meters per axis, from which individual observations will be made.
        /// </summary>
        /// <remarks>
        /// When used when <see cref="ObserverVolumeType"/> is set to <see cref="VolumeType.Spherical"/> the X axis value of the vector will be
        /// used as the radius of the sphere.
        /// </remarks>
        Vector3 ObservationExtents { get; set; }

        /// <summary>
        /// Gets or sets the orientation of the volume.
        /// </summary>
        Quaternion ObserverOrientation { get; set; }

        /// <summary>
        /// Gets or sets the origin of the observer.
        /// </summary>
        /// <remarks>
        /// Moving the observer origin allows the spatial awareness system to locate and discard meshes as the user
        /// navigates the environment.
        /// </remarks>
        Vector3 ObserverOrigin { get; set; }

        /// <summary>
        /// Gets or sets the frequency, in seconds, at which the spatial observer should update.
        /// </summary>
        float UpdateInterval { get; set; }

        /// <summary>
        /// Start | resume the observer.
        /// </summary>
        void Resume();

        /// <summary>
        /// Stop | pause the observer
        /// </summary>
        void Suspend();
    }
}