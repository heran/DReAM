﻿/*
 * MindTouch Dream - a distributed REST framework 
 * Copyright (C) 2006-2011 MindTouch, Inc.
 * www.mindtouch.com  oss@mindtouch.com
 *
 * For community documentation and downloads visit wiki.developer.mindtouch.com;
 * please review the licensing section.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using MindTouch.Collections;
using NUnit.Framework;

namespace MindTouch.Dream.Test.Collections {

    [TestFixture]
    public class LockFreeQueueTests {

        //--- Methods ---

        [Test]
        public void New_Count() {
            var q = new LockFreeQueue<int>();
            Assert.AreEqual(0, q.Count);
        }

        [Test]
        public void New_TryDequeue_Count() {
            int value;
            var q = new LockFreeQueue<int>();
            Assert.AreEqual(0, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(0, q.Count);
        }

        [Test]
        public void New_TryDequeue_TryDequeue_Count() {
            int value;
            var q = new LockFreeQueue<int>();
            Assert.AreEqual(0, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(0, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(0, q.Count);
        }

        [Test]
        public void New_TryEnqueue_Count() {
            var q = new LockFreeQueue<int>();
            Assert.AreEqual(0, q.Count);

            q.TryEnqueue(42);
            Assert.AreEqual(1, q.Count);
        }

        [Test]
        public void New_TryEnqueue_TryDequeue_Count() {
            int value;
            var q = new LockFreeQueue<int>();
            Assert.AreEqual(0, q.Count);

            q.TryEnqueue(42);
            Assert.AreEqual(1, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(42, value);
            Assert.AreEqual(0, q.Count);
        }

        [Test]
        public void New_TryDequeue_TryEnqueue_Count() {
            int value;
            var q = new LockFreeQueue<int>();
            Assert.AreEqual(0, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(0, q.Count);

            q.TryEnqueue(42);
            Assert.AreEqual(1, q.Count);
        }

        [Test]
        public void New_TryDequeue_TryEnqueue_TryDequeue_Count() {
            int value;
            var q = new LockFreeQueue<int>();
            Assert.AreEqual(0, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(0, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(0, q.Count);

            q.TryEnqueue(42);
            Assert.AreEqual(1, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(42, value);
            Assert.AreEqual(0, q.Count);
        }

        [Test]
        public void New_TryDequeue_TryEnqueue_TryDequeue_TryDequeue_Count() {
            int value;
            var q = new LockFreeQueue<int>();
            Assert.AreEqual(0, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(0, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(0, q.Count);

            q.TryEnqueue(42);
            Assert.AreEqual(1, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(42, value);
            Assert.AreEqual(0, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(0, q.Count);
        }

        [Test]
        public void New_TryEnqueue_x50_Count() {
            int value;
            var q = new LockFreeQueue<int>();
            Assert.AreEqual(0, q.Count);

            for(int i = 0; i < 50; ++i) {
                q.TryEnqueue(100 - i);
            }
            Assert.AreEqual(50, q.Count);

            for(int i = 0; i < 50; ++i) {
                q.TryDequeue(out value);
                Assert.AreEqual(100 - i, value);
            }
            Assert.AreEqual(0, q.Count);
        }

        [Test]
        public void New_TryEnqueue_x50_TryDequeue_x50_Count() {
            int value;
            var q = new LockFreeQueue<int>();
            Assert.AreEqual(0, q.Count);

            for(int i = 0; i < 50; ++i) {
                q.TryEnqueue(100 - i);
            }
            Assert.AreEqual(50, q.Count);

            for(int i = 0; i < 50; ++i) {
                q.TryDequeue(out value);
                Assert.AreEqual(100 - i, value);
            }
            Assert.AreEqual(0, q.Count);
        }

        [Test]
        public void New_TryEnqueue_x50_TryDequeue_x50_TryDequeue_Count() {
            int value;
            var q = new LockFreeQueue<int>();
            Assert.AreEqual(0, q.Count);

            for(int i = 0; i < 50; ++i) {
                q.TryEnqueue(100 - i);
            }
            Assert.AreEqual(50, q.Count);

            for(int i = 0; i < 50; ++i) {
                q.TryDequeue(out value);
                Assert.AreEqual(100 - i, value);
            }
            Assert.AreEqual(0, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(0, q.Count);
        }

        [Test]
        public void New_TryDequeue_TryEnqueue_x50_TryDequeue_x50_TryDequeue_Count() {
            int value;
            var q = new LockFreeQueue<int>();
            Assert.AreEqual(0, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(0, q.Count);

            for(int i = 0; i < 50; ++i) {
                q.TryEnqueue(100 - i);
            }
            Assert.AreEqual(50, q.Count);

            for(int i = 0; i < 50; ++i) {
                q.TryDequeue(out value);
                Assert.AreEqual(100 - i, value);
            }
            Assert.AreEqual(0, q.Count);

            q.TryDequeue(out value);
            Assert.AreEqual(0, q.Count);
        }
    }
}
