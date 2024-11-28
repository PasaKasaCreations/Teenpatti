using UnityEngine;

namespace Constants
{
    public static class SocketEvents
    {
        [Header("Emit")]
        public const string GameRoomJoin = "gameroom:join";
        public const string GameRoomLeave = "gameroom:leave";
        public const string GameRoomCheck = "gameroom:check";

        [Header("Listen")]
        public const string ConnectResponse = "connect";
        public const string GameRoomJoinResponse = "gameroom:join-response";
        public const string GameRoomLeaveResponse = "gameroom:leave-response";
        public const string GameRoomUpdateResponse = "gameroom:update-response";
        public const string GameRoomClosedResponse = "gameroom:closed";
        public const string GameRoomTransferPlayerResponse = "gameroom:transfer-player";
        public const string MaxPlayersReachedResponse = "maxPlayersReached";

        [Header("Errors")]
        public const string Error = "error";
        public const string ConnectError = "connect_error";
        public const string ConnectFailed = "connect_failed";
    }
}
