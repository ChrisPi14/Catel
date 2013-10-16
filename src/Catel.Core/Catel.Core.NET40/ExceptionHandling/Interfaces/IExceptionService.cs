﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExceptionService.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.ExceptionHandling
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This interface describes a simple Exception service.
    /// </summary>
    public interface IExceptionService
    {
        #region Events
        /// <summary>
        /// Occurs when an action is retrying.
        /// </summary>
        event EventHandler<RetryingEventArgs> RetryingAction;

        /// <summary>
        /// Occurs when an exception is buffered. 
        /// </summary>
        event EventHandler<BufferedEventArgs> ExceptionBuffered;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the exception handlers.
        /// </summary>
        IEnumerable<IExceptionHandler> ExceptionHandlers { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Determines whether the specified exception type is registered.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <returns>
        ///   <c>true</c> if the exception type is registered; otherwise, <c>false</c>.
        /// </returns>
        bool IsExceptionRegistered<TException>() where TException : Exception;

        /// <summary>
        /// Determines whether the specified exception type is registered.
        /// </summary>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <returns>
        ///   <c>true</c> if the specified exception type is registered; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">The <paramref ref="exceptionType"/> is <c>null</c>.</exception>
        bool IsExceptionRegistered(Type exceptionType);

        /// <summary>
        /// Registers a specific exception including the handler.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="handler">The action to execute when the exception occurs.</param>
        /// <returns>The handler to use.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="handler"/> is <c>null</c>.</exception>
        IExceptionHandler Register<TException>(Action<TException> handler)
            where TException : Exception;

        /// <summary>
        /// Unregisters a specific exception for handling.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <returns><c>true</c> if the exception is unsubscribed; otherwise <c>false</c>.</returns>
        bool Unregister<TException>()
            where TException : Exception;

        /// <summary>
        /// Handles the specified exception if possible.
        /// </summary>
        /// <param name="exception">The exception to handle.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="exception"/> is <c>null</c>.</exception>
        /// <returns><c>true</c> if the exception is handled; otherwise <c>false</c>.</returns>
        bool HandleException(Exception exception);

        /// <summary>
        /// Processes the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="action"/> is <c>null</c>.</exception>
        void Process(Action action);

        /// <summary>
        /// Processes the specified action.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The <paramref name="action"/> is <c>null</c>.</exception>
        TResult Process<TResult>(Func<TResult> action);

        /// <summary>
        /// Processes the specified action with possibilty to retry on error.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="action"/> is <c>null</c>.</exception>
        void ProcessWithRetry(Action action);

        /// <summary>
        /// Processes the specified action with possibilty to retry on error.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The <paramref name="action"/> is <c>null</c>.</exception>
        TResult ProcessWithRetry<TResult>(Func<TResult> action);
        #endregion
    }
}